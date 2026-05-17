using Google.Apis.Auth.OAuth2;
using Google.Apis.Drive.v3;
using Google.Apis.Services;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace RecommendationSystem
{
    public partial class WebForm4 : System.Web.UI.Page
    {
        private const string PathToServiceAccountKeyFile = @"C:\Users\moham\Desktop\University\4th year\Graduation Project\Implementation\RecommendationSystem\RecommendationSystem\Credentials\recommendationdrive.json";
        private const string ServiceAccountEmail = "adminservice@recommendationdrive.iam.gserviceaccount.com";
        private const string DirectoryId = "1NitW5D9BCeYU6EUe1WiUFKrJ2mpXbWLI";

        protected void Page_Load(object sender, EventArgs e)
        {
            string filePath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Desktop), "Final_Filtered_Frame.csv");

            if (!File.Exists(filePath))
            {
                Upload.Enabled = true;
                validationMessage.Text = "";
            }
            else
            {
                Upload.Enabled = false;
                validationMessage.Text = "Final_Filtered_Frame.csv file already exists in your system.";
            }
        }
            protected void UploadScheduleValidator_ServerValidate(object source, ServerValidateEventArgs args)
        {
            if (UploadSchedule.HasFile)
            {
                string fileExtension = System.IO.Path.GetExtension(UploadSchedule.FileName);
                if (fileExtension != ".csv")
                {
                    args.IsValid = false;
                }
                else
                {
                    args.IsValid = true;
                }
            }
            else
            {
                args.IsValid = true;
            }
        }

        protected void Upload_Click(object sender, EventArgs e)
        {
            if (Page.IsValid)
            {
                if (UploadSchedule.HasFile)
                {
                    using (var reader = new StreamReader(UploadSchedule.FileContent))
                    {
                        var header = reader.ReadLine();
                        var columns = header.Split(',');

                        if (!CheckRequiredColumns(columns))
                        {
                            // Display error message
                            Response.Write("<script>alert('The uploaded file does not contain the required columns.');</script>");
                            return;
                        }


                        var credential = GoogleCredential.FromFile(PathToServiceAccountKeyFile)
                            .CreateScoped(DriveService.ScopeConstants.Drive);

                        var service = new DriveService(new BaseClientService.Initializer()
                        {
                            HttpClientInitializer = credential
                        });

                        // Retrieve the list of existing files in the target directory
                        var listRequest = service.Files.List();
                        listRequest.Q = $"'{DirectoryId}' in parents and mimeType='text/csv' and trashed=false";
                        var existingFiles = listRequest.Execute().Files;

                        // Delete existing files in the directory
                        foreach (var existingFile in existingFiles)
                        {
                            var deleteRequest = service.Files.Delete(existingFile.Id);
                            deleteRequest.Execute();
                        }

                        var fileMetadata = new Google.Apis.Drive.v3.Data.File()
                        {
                            Name = UploadSchedule.FileName,
                            Parents = new List<string>() { DirectoryId }
                        };

                        using (var stream = UploadSchedule.FileContent)
                        {
                            var uploadRequest = service.Files.Create(fileMetadata, stream, "text/csv");
                            uploadRequest.Fields = "*";
                            var results = uploadRequest.Upload();

                            if (results.Status != Google.Apis.Upload.UploadStatus.Completed)
                            {
                                Console.WriteLine($"Error uploading file: {results.Exception.Message}");
                                Response.Write("<script>alert('Error occurred while uploading the file: " + results.Exception.Message + "');</script>");
                            }
                            else
                            {
                                Response.Write("<script>alert('File uploaded successfully!');</script>");
                                validationMessage.Text = "Please wait until the uploaded file is done being processed.";

                                Timer timer = new Timer();
                                timer.Interval = 30000;
                                timer.Tick += (s, args) =>
                                {
                                    Upload.Enabled = true;
                                    validationMessage.Text = "";
                                    timer.Enabled = false;
                                };
                                timer.Enabled = true;
                            }
                        }
                    }
                }
            }
        }

        private bool CheckRequiredColumns(string[] columnNames)
        {
            var requiredColumns = new List<string>()
    {
        "Course Name",
        "Course Section",
        "Capacity",
        "Day",
        "Orientation Days",
        "Time",
        "Hall Name",
        "Instructor Name",
        "Credit Hours"
    };

            foreach (var requiredColumn in requiredColumns)
            {
                if (!columnNames.Contains(requiredColumn))
                {
                    return false;
                }
            }

            return true;
        }
    }
}
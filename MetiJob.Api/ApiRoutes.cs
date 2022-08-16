namespace MetiJob.Api
{
    public static class ApiRoutes
    {
        public const string BaseRoute = "api/v{version:apiVersion}/[controller]";
        public static class Identity
        {
            public const string RegisterUser = "register";
            public const string LoginUser = "login";
            public const string ForgotPassword = "forget-pass/{email}";
            public const string ResetPassword = "reset-pass";
            public const string ChangePassword = "change-pass/{email}";
        }
        public static class Jobs
        {
            public const string SendResume= "send-resume";
        }
        public static class Resume
        {
            public const string UpdatePersonalInformation = "update-personal-information";
            public const string UpdateSkills = "update-skills";
            public const string UpdateWorkExperience = "update-work-experience";
            public const string UpdateEducationalRecords = "update-educational-records";
            public const string UpdateLanguage = "update-language";
            public const string UpdateCareerJob = "update-career-job";
            public const string UploadUserAvatar = "upload-user-avatar/{userId}";
            public const string UploadResume = "upload-resume/{userId}";
            public const string ToggleIsSeeableResume = "toggle-isSeeable-resume/{userId}";
            public const string GetResumeItems = "{userId}";
            public const string DeleteLnaguage = "delete-language/{id}";
            public const string DeleteEducationalRecord = "delete-educational-record/{id}"; 
            public const string DeleteWorkExperience= "delete-work-experience/{id}"; 

        }
        public class Companies
        {
            public const string Top50 = "top-50";
        }
    }
}

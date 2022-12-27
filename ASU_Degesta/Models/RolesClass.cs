using Microsoft.AspNetCore.Authorization.Infrastructure;

namespace ASU_Degesta.Models
{
    public static class Operations
    {
        public static OperationAuthorizationRequirement Create =   
            new OperationAuthorizationRequirement {Name=RolesConstants.CreateOperationName};
        public static OperationAuthorizationRequirement Read = 
            new OperationAuthorizationRequirement {Name=RolesConstants.ReadOperationName};  
        public static OperationAuthorizationRequirement Update = 
            new OperationAuthorizationRequirement {Name=RolesConstants.UpdateOperationName}; 
        public static OperationAuthorizationRequirement Delete = 
            new OperationAuthorizationRequirement {Name=RolesConstants.DeleteOperationName};
        public static OperationAuthorizationRequirement WatchGlobal = 
            new OperationAuthorizationRequirement {Name=RolesConstants.WatchGlobalOperationName};
    }

    public class RolesConstants
    {
        public static readonly string CreateOperationName = "Create";
        public static readonly string ReadOperationName = "Read";
        public static readonly string UpdateOperationName = "Update";
        public static readonly string DeleteOperationName = "Delete";
        public static readonly string WatchGlobalOperationName = "WatchGlobal";

        public static readonly string AdminRole = 
            "Admin";
        public static readonly string GeneralDirectorRole = 
            "GeneralDirector";
        public static readonly string AccountantRole = "Accountant";
    }
}
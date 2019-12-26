using System;
using System.Collections.Generic;
using System.Text;

namespace geektrust.Models
{

    public static class Commands
    {
        public const String ADD_CHILD = "ADD_CHILD";
                      
        public const String GET_RELATIONSHIP = "GET_RELATIONSHIP";
    }

    public static class Messages
    {
        public static readonly String PERSON_NOT_FOUND = "PERSON_NOT_FOUND";

        public static readonly String CHILD_ADDITION_FAILED = "CHILD_ADDITION_FAILED";

        public static readonly String CHILD_ADDITION_SUCCEEDED = "CHILD_ADDITION_SUCCEEDED";

        public static readonly String NONE = "NONE";

        public static readonly String INVALID_COMMAND = "INVALID COMMAND";

        public static readonly String DULPLICATE_PERSON_ERROR = "DUPLICATE_PERSON_NAME_NOT_ALLOWED";
    }


    public enum Gender
    {
        Male,
        Female
    }
}

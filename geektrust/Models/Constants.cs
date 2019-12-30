using System;
using System.Collections.Generic;
using System.Text;

namespace geektrust.Models
{

    public static class Commands
    {
        public const String ADD_CHILD = "ADD_CHILD";
                      
        public const String GET_RELATIONSHIP = "GET_RELATIONSHIP";

        public const String ADD_HEAD = "ADD_HEAD";

        public const String ADD_SPOUSE = "ADD_SPOUSE";
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

    public static class Relations
    {
        public static readonly String Son = "Son";

        public static readonly String Daughter = "Daughter";

        public static readonly String Siblings = "Siblings";

        public static readonly String Paternal_Uncle = "Paternal-Uncle";

        public static readonly String Maternal_Uncle = "Maternal-Uncle";

        public static readonly String Paternal_Aunt = "Paternal-Aunt";

        public static readonly String Maternal_Aunt = "Maternal-Aunt";

        public static readonly String Sister_In_Law = "Sister-In-Law";

        public static readonly String Brother_In_Law = "Brother-In-Law";
    }


    public enum Gender
    {
        Male,
        Female
    }
}

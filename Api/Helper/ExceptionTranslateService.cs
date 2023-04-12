namespace Api.Helper
{
    public class ExceptionTranslateService
    {
        public string Translate(string errorMessage)
        {
            switch (errorMessage)
            {
                case "Sequence contains no elements":
                    return "مشترک مورد نظر وجود ندارد";
                default:
                    return "خطای سیستمی رخ داده است";
            }
        }
    }
}

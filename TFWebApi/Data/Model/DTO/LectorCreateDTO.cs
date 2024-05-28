using FluentValidation;

namespace TFWebApi.Data.Model.DTO
{
    public class LectorCreateDTO
    {
        public string Name { get; set; }
        public string Email { get; set; }
    }

    public class LectorCreateValidator : AbstractValidator<LectorCreateDTO>
    {
        public LectorCreateValidator()
        {
            RuleFor(l => l.Name).NotEmpty();
            RuleFor(l => l.Email).EmailAddress();
            //RuleFor(l => l.Url).NotEmpty().Must(BeValidUrl);
        }

        //private bool BeValidUrl(string url)
        //{
        //    return Uri.TryCreate(url, UriKind.Absolute, out Uri validatedUri) && (validatedUri.Scheme == Uri.UriSchemeHttp
        //        || validatedUri.Scheme == Uri.UriSchemeHttps);
        //}
    }
}

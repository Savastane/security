namespace security.api.Application
{
    using MediatR;

    public class FillDatabaseRequest : IRequest<FillDatabaseResponse>
    {
        public string Action { get; set; }


        public string Audiencia;

        public FillDatabaseRequest()
        {
            Action = "filldatabase";
        }

        public string GetBanco()
        {
            return Audiencia ?? "security";
        }

    }
}

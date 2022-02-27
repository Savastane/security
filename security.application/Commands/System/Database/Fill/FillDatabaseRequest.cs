


namespace security.application
{
    using MediatR;

    public class FillDatabaseRequest : IRequest<FillDatabaseResponse>
    {
        public string Action { get; set; }
        

        public string Audiencia;

        public FillDatabaseRequest()
        {
            this.Action = "filldatabase";
        }

    }
}

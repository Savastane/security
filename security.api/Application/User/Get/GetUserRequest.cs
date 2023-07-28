namespace security.api.Application
{
    using MediatR;

    public class GetUserRequest : IRequest<GetUserResponse>
    {

        public string Id { get; set; }
        public string Banco { get; set; }


        public GetUserRequest(string Id)
        {
            this.Id = Id;

        }

        public string GetBanco()
        {
            return Banco ?? "security";
        }
    }
}

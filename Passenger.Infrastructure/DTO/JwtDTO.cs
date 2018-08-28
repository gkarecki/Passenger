namespace Passenger.Infrastructure.DTO
{
    //data from token
    public class JwtDTO
    {
        public string Token { get; set; }
        public long Expires { get; set; }
    }
}
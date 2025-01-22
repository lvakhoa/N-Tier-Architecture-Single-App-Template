namespace EVOffice_BE.Shared.Claim
{
    public interface IClaimService
    {
        string GetUserId();

        string GetClaim(string key);
    }
}

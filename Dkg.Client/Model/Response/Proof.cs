namespace Dkg.Client.Model.Response
{
    public class Proof
    {
        public string Triple { get; set; }
        public string TripleHash { get; set; }
        public List<ProofData> Proofs { get; set; }
    }
}

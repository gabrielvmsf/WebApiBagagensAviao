namespace WebApplicationBagagens.Dto.Autor
{
    public class BagagemEdicaoDto
    {
        public int Id { get; set; } 
        public int PassageiroID { get; set; }
        public int VooID { get; set; }
        public double Peso { get; set; }
        public string Dimensoes { get; set; }
        public string Tipo { get; set; }
        public string Status { get; set; }
        public DateTime DataRegistro { get; set; }
        public string? Observacoes { get; set; }
    }
}

using LiteDB;

namespace InventarioMobileApp.Models
{
    public class InventoryModel
    {
        public string cnpj { get; set; }
        [BsonId]
        public string Ean { get; set; }
        public string Descricao { get; set; }
        public decimal qtd { get; set; }
        public decimal valor { get; set; }
        public string status { get; set; }

        override public string ToString()
        {
            return $"{cnpj};{Ean};{Descricao};{qtd};{valor};{status}";
        }
    }
}

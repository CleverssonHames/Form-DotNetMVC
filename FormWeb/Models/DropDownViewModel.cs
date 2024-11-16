namespace FormWeb.Models;

public class DropDownViewModel : TiposViewModel
{
    public int idfiltro { get; set; }
    public List<TipoB> tipoBFiltrada = new();
}
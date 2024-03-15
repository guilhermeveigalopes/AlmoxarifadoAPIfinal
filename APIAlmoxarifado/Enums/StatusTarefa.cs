using System.ComponentModel;

namespace APIAlmoxarifado.Enums
{
    public enum StatusTarefa
    {
        [Description("A fazer")]
        AFazer = 1,
        [Description("Em andameto")]
        EmAndamento = 2,
        [Description("Concluido")]
        Concluido = 3
    }
}

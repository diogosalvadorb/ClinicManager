namespace ClinicManager.Core.Entities
{
    public class User : BaseEntity
    {
        public string Login { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
        public bool Active { get; set; }
        public string Role { get; set; } = string.Empty;
        public Paciente? Paciente { get; set; }
        public Medico? Medico { get; set; }
    }
}

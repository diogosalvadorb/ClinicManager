﻿namespace ClinicManager.Core.Entities
{
    public class Usuario : BaseEntity
    {
        public Usuario(string login, string senha, bool ativo, string perfil)
        {
            Login = login;
            Senha = senha;
            Ativo = ativo;
            Perfil = perfil;
        }

        public string Login { get; set; } = string.Empty;
        public string Senha { get; set; } = string.Empty;
        public bool Ativo { get; set; }
        public string Perfil { get; set; } = string.Empty;
        public Guid IdPaciente { get; set; }
        public Guid IdMedico { get; set; }
    }
}

using BCrypt.Net;
namespace webApi.EventPlus.Utils.Criptografia
{
    public static class Criptografia
    {
        /// <summary>
        /// metodo para criptografar senhas
        /// </summary>
        /// <param name="senha"> senha que sera criptografada</param>
        /// <returns>gash da senha criptografada em BCrypt</returns>
        public static string GerarHash(string senha)
        {
            return BCrypt.Net.BCrypt.HashPassword(senha);
        }

        public static bool VerificarHash(string senhaForm, string senhaBanco)
        {
            return BCrypt.Net.BCrypt.Verify(senhaForm, senhaBanco);

        }
    }
}

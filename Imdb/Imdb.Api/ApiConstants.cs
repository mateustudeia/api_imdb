using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Imdb.Api
{
    public static class ApiConstants
    {
        public const string ERR_GENERIC = "Ocorreu um erro ao tentar processar sua requisição, tente novamente mais tarde.";
        public const string ERR_EMAIL_IN_USE = "O email informado já está em uso.";
        public const string ERR_EMAIL_PASSWORD_INCORRECT = "Login e/ou senha incorretos.";

        public const string MSG_LOGIN_SUCCESS = "Login relizado com sucesso.";
        public const string MSG_REGISTER_SUCCESS = "Cadastro relizado com sucesso.";
        public const string MSG_GENERIC_GET_SUCCESS = "Dados consultados com sucesso.";
        public const string MSG_GENERIC_UPDATE_SUCCESS = "Dados atualizados com sucesso.";
        public const string MSG_GENERIC_SUCCESS = "Operação realizada com sucesso.";
    }
}

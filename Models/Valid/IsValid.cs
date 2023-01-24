using System.ComponentModel.DataAnnotations;
using System.Drawing;

namespace MinimalApi.Models.Valid
{
    public class IsValid
    {
      
        public static bool IsValidCPF(string cpf)
                {
                    bool isValid = true;
                    if (string.IsNullOrWhiteSpace(cpf) || cpf.Length != 11)
                    {
                        isValid = false;
                    }
                    else
                    {
                        for (int i = 0; i < cpf.Length; i++)
                        {
                            if (!Char.IsDigit(cpf[i]))
                            {
                                isValid = false;
                                break;
                            }
                        }
                    }
                    return isValid;
                }
    }
}

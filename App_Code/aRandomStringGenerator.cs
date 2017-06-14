using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;


/// <summary>
/// Summary description for aRandomStringGenerator
/// </summary>
public class aRandomStringGenerator
{
    static Random rSeed = new Random();

    public virtual string makeAString(int passwordLength, bool strongPassword)
	{
         int seed = rSeed.Next(1, int.MaxValue);
        //const string allowedChars = "ABCDEFGHJKLMNOPQRSTUVWXYZ0123456789";
        const string allowedChars = "abcdefghijkmnopqrstuvwxyzABCDEFGHJKLMNOPQRSTUVWXYZ0123456789";
        const string specialCharacters = @"!#$%&'()*+,-./:;<=>?@[\]_";

        var chars = new char[passwordLength];
        var rd = new Random(seed);

        for (var i = 0; i < passwordLength; i++)
        {
            // If we are to use special characters
            if (strongPassword && i % rSeed.Next(3, passwordLength) == 0)
            {
                chars[i] = specialCharacters[rd.Next(0, specialCharacters.Length)];
            }
            else
            {
                chars[i] = allowedChars[rd.Next(0, allowedChars.Length)];
            }
        }

        return new string(chars);
	}
}
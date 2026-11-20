namespace StringPractice;

public static class CaesarCipher
{
    public static string Encrypt(string text, int shift)
    {
        char[] buffer = text.ToCharArray();
        shift %= 26;

        for (int i = 0; i < buffer.Length; i++)
        {
            char c = buffer[i];
            if (c >= 'A' && c <= 'Z')
            {
                buffer[i] = (char)('A' + (c - 'A' + shift + 26) % 26);
            }
            else if (c >= 'a' && c <= 'z')
            {
                buffer[i] = (char)('a' + (c - 'a' + shift + 26) % 26);
            }
        }

        return new string(buffer);
    }

    public static string Decrypt(string text, int shift)
    {
        return Encrypt(text, -shift);
    }
}

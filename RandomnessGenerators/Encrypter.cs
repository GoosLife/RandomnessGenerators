namespace RandomnessGenerators
{
    internal class Encrypter
    {
        private byte Shift;
        private string Alphabet;

        public Encrypter(byte shift = 10, string alphabet = "ABCDEFGHIJKLMNOPQRSTUVWXYZÆØÅ")
        {
            this.Shift = shift;
            this.Alphabet = alphabet;
        }

        /// <summary>
        /// Encrypt a message by shifting each character a pre-determined number of steps in the alphabet, wrapping around if necessary.
        /// </summary>
        /// <param name="message"></param>
        /// <returns></returns>
        public string Encrypt(string message)
        {
            // Array to contain the output
            char[] chars = new char[message.Length];

            for (int i = 0; i < message.Length; i++)
            {
                // Get the index of the character in the alphabet
                int index = Alphabet.IndexOf(char.ToUpper(message[i]));

                if (index != -1) // Character found in the Alphabet
                {
                    chars[i] = Alphabet[(index + Shift) % Alphabet.Length]; // Shift the character and wrap around if necessary
                }
                else // Character not found, keep it as is
                {
                    chars[i] = message[i];
                }
            }
            return new string(chars);
        }

        /// <summary>
        /// Decrypt an encrypted message.
        /// There are optional parameters for shift and alphabet, which can be used to decrypt messages encrypted with different shift or alphabet.
        /// (Or, for demonstration purposes, to prove how switching the alphabet can mess up the decryption.)
        /// </summary>
        /// <param name="encryptedMessage"></param>
        /// <param name="shift"></param>
        /// <param name="alphabet"></param>
        /// <returns></returns>
        public string Decrypt(string encryptedMessage, byte? shift = null, string? alphabet = null)
        {

            // Initialize shift and alphabet
            if (shift == null) shift = this.Shift;

            if (alphabet == null) alphabet = this.Alphabet;
            else alphabet = alphabet!.ToUpper();

            // Char array to hold the output
            char[] chars = new char[encryptedMessage.Length];

            for (int i = 0; i < encryptedMessage.Length; i++)
            {
                // Get the index of the character in the alphabet
                int index = Alphabet.IndexOf(char.ToUpper(encryptedMessage[i]));
                
                if (index != -1) // Character found in the Alphabet
                {
                    // Properly handle negative shift for decryption
                    int shiftedIndex = (index - Shift) % Alphabet.Length;
                    if (shiftedIndex < 0) shiftedIndex += Alphabet.Length;
                    chars[i] = Alphabet[shiftedIndex];
                }
                else // Character not found, keep it as is
                {
                    chars[i] = encryptedMessage[i];
                }
            }

            return new string(chars);
        }
    }
}

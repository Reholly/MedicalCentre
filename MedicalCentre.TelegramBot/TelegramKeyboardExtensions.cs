using Telegram.Bot.Types.ReplyMarkups;

namespace MedicalCentre.TelegramBot
{
    public static class TelegramKeyboardExtensions
    {
        public static KeyboardButton[][] ToRows(this KeyboardButton[] buttons, int rowSize)
        {
            /*
            if (buttons.Length <= rowSize)
            {
                var resSmall = new KeyboardButton[1][];
                resSmall[0] = new KeyboardButton[buttons.Length];
                for (int i = 0; i < buttons.Length; i++)
                {
                    resSmall[0][i] = buttons[i];
                }
                return resSmall;
            }
            */
            int rowsCount = buttons.Length % rowSize == 0 ? buttons.Length / rowSize : buttons.Length / rowSize + 1;
            var res = new KeyboardButton[rowsCount][];

            for (int i = 0; i < rowsCount; i++)
            {
                for (int j = 1; j < rowSize; j++)
                {
                    if(i * 3 + j == buttons.Length)
                    {
                        res[i] = new KeyboardButton[j];
                        break;
                    }
                    res[i] = new KeyboardButton[rowSize];
                }
                for (int j = 0; j < res[i].Length; j++)
                {
                    res[i][j] = buttons[i * 3 + j];
                }
            }
            return res;
        }

        public static KeyboardButton[] AddBackButton(this KeyboardButton[] buttons)
        {
            var res = new KeyboardButton[buttons.Length + 1];
            buttons.CopyTo(res, 0);
            res[res.Length - 1] = new KeyboardButton("Назад");
            return res;
        }
    }
}

namespace DoctorClass.Models
{
    class CardProblem
    {
        public bool IsValid(long cardNumber)
        {
            String numberLength=cardNumber.ToString();
            if(numberLength.Length<16 || numberLength.Length > 16) { 
                return false;
            }

            long sum = RevAndSum(cardNumber);
            Console.WriteLine(sum);
            if (sum % 10 == 0)
            {
                return true;
            }
            else
            {
                return false;
            }

        }

        public long RevAndSum(long cardNumber)
        {
            long sum = 0;
            long reversedNumber = 0;
            int pos = 1;
            while (cardNumber > 0)
            {
                reversedNumber = reversedNumber * 10 + cardNumber % 10;
                if (pos % 2 == 0)
                {
                    long num = (cardNumber % 10) * 2;
                    if (num > 9)
                    {
                        num = num % 10 + num / 10;
                    }
                    sum += num;
                }
                else
                {
                    sum += (cardNumber % 10);
                }
                pos++;
                cardNumber /= 10;
            }
            return sum;
        }
    }
}

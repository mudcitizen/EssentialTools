namespace EssentialTools.Models
{

    public interface IDiscountHelper
    {

        decimal ApplyDiscount(decimal totalParam);
    }

    public class DefaultDiscountHelper : IDiscountHelper
    {
        protected decimal DiscountSize = 10;

        public DefaultDiscountHelper(decimal discountSize) {
            DiscountSize = discountSize;
        }
        public decimal ApplyDiscount(decimal totalParam)
        {
            return (totalParam - (DiscountSize / 100m * totalParam));
        }
    }
}
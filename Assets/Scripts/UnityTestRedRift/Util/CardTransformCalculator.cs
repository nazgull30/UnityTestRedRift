namespace UnityTestRedRift.Util
{
    public class CardTransformCalculator
    {

        public float CalcPositionX(int index, int cardCount, float distanceBetweenCards)
        {
            var middle = cardCount / 2;
            if (index < middle)
            {
                return -(middle - index) * distanceBetweenCards;
            }

            if(index > middle)
            {
                return (index - middle) * distanceBetweenCards;
            }
            
            return 0;
        }
        
        public float CalcPositionY(int index, int cardCount, float deltaPosY)
        {
            var middle = cardCount / 2;
            if (index < middle)
            {
                return -(middle - index) * deltaPosY;
            }

            if(index > middle)
            {
                return -(index - middle) * deltaPosY;
            }
            
            return 0;
        }
        
        
        public float CalcRotationZ(int index, int cardCount, float deltaRotation)
        {
            var middle = cardCount / 2;
            if (index <= middle)
            {
                return (middle - index) * deltaRotation;
            }

            if(index > middle)
            {
                return -(index - middle) * deltaRotation;
            } 
            
            return 0;
        }
    }
    
    
}
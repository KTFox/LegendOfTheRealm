
namespace LegendOfTheRealm.Utilities
{
    public class LazyValue<T>
    {
        // Variables

        private T value;
        private bool hasInitialized = false;
        private InitializerDelegate initializer;

        // Delegates

        public delegate T InitializerDelegate();

        // Properties

        public T Value
        {
            get
            {
                ForceInit();
                return value;
            }
            set
            {
                hasInitialized = true;
                this.value = value;
            }
        }

        // Constructor

        public LazyValue(InitializerDelegate initializer)
        {
            this.initializer = initializer;
        }


        // Methods

        public void ForceInit()
        {
            if (!hasInitialized)
            {
                value = initializer();
                hasInitialized = true;
            }
        }
    }
}

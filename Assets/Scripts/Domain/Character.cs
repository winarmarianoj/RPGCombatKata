namespace Domain
{
    public class Character
    {
        public int hp;
        public int level;
        public bool isAlive;
        private const int STARTING_LEVEL = 1;
        private const int STARTING_HP = 1000;
        public Character()
        {
            hp = STARTING_HP;
            level = STARTING_LEVEL;
            isAlive = true;
        }
    }
}
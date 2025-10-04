using Microsoft.VisualStudio.TestTools.UnitTesting;
using Ucu.Poo.RoleplayGame;

namespace RoleplayGameTests
{
    [TestClass]
    public class WizardTests
    {
        private Wizard wizard;
        private Staff staff;
        private SpellsBook book;

        [TestInitialize]
        public void Setup()
        {
            Spell fireball = new Spell();
            Spell shield = new Spell();

            book = new SpellsBook
            {
                Spells = new Spell[] { fireball, shield }
            };

            staff = new Staff();

            wizard = new Wizard("Gandalf")
            {
                SpellsBook = book,
                Staff = staff
            };
        }

        [TestMethod]
        public void Wizard_HasCorrectName()
        {
            Assert.AreEqual("Gandalf", wizard.Name);
        }

        [TestMethod]
        public void AttackValue_IsSumOfStaffAndSpells()
        {
            int expected = staff.AttackValue + book.AttackValue;
            Assert.AreEqual(expected, wizard.AttackValue);
        }

        [TestMethod]
        public void DefenseValue_IsSumOfStaffAndSpells()
        {
            int expected = staff.DefenseValue + book.DefenseValue;
            Assert.AreEqual(expected, wizard.DefenseValue);
        }

        [TestMethod]
        public void ReceiveAttack_ReducesHealth()
        {
            int initialHealth = wizard.Health;
            wizard.ReceiveAttack(500);

            Assert.IsTrue(wizard.Health < initialHealth);
        }

        [TestMethod]
        public void ReceiveAttack_DoesNotGoBelowZero()
        {
            wizard.ReceiveAttack(9999);
            Assert.AreEqual(0, wizard.Health);
        }

        [TestMethod]
        public void Cure_RestoresHealth()
        {
            wizard.ReceiveAttack(500);
            Assert.IsTrue(wizard.Health < 100);

            wizard.Cure();
            Assert.AreEqual(100, wizard.Health);
        }

        [TestMethod]
        public void ReceiveAttack_WeakerThanDefense_DoesNotReduceHealth()
        {
            int initialHealth = wizard.Health;
            wizard.ReceiveAttack(50); 
            Assert.AreEqual(initialHealth, wizard.Health);
        }
    }
}

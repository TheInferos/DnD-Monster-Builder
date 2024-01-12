using Monster_Builder_Web_API.Models;

namespace UnitTests
{
    [TestClass]
    public class WeaponTests
    {
        [TestMethod]
        public void Weapon_Name_SetCorrectly()
        {
            // Arrange
            string expectedName = "Longsword";
            Weapon weapon = new ();

            // Act
            weapon.Name = expectedName;

            // Assert
            Assert.AreEqual(expectedName, weapon.Name);
        }
    }
}
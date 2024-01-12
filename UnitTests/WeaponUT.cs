using Monster_Builder_Web_API.Models;
using Monster_Builder_Web_API.Models.DTOs;

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
        [TestMethod]
        public void WeaponConstructionFromDTO_ShouldSetPropertiesCorrectly()
        {
            // Arrange
            var weaponDTO = new WeaponDTO
            {
                Name = "Sword of Testing",
                Damage = "2d6",
                Properties = new List<string> { "Versatile", "Finesse", "Heavy", "Two-Handed" },
                Martial = true,
                Ranged = false,
                Cost = 50,
                Weight = 5
            };

            // Act
            var weapon = new Weapon(weaponDTO);

            // Assert
            Assert.AreEqual(weaponDTO.Name, weapon.Name);
            Assert.AreEqual(weaponDTO.Damage, weapon.Damage);
            CollectionAssert.AreEquivalent(weaponDTO.Properties, weapon.Properties);
            Assert.AreEqual(weaponDTO.Martial, weapon.Martial);
            Assert.AreEqual(weaponDTO.Ranged, weapon.Ranged);
            Assert.AreEqual(weaponDTO.Cost, weapon.Cost);
            Assert.AreEqual(weaponDTO.Weight, weapon.Weight);
            // Add more assertions as needed for other properties
        }

    }
}
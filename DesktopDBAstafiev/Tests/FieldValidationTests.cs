using DesktopDBAstafiev.Classes;
using NUnit.Framework;
using System;

namespace DesktopDBAstafiev.Test
{
    [TestFixture]
    public class FieldValidationTests
    {
        [Test]
        public void Validate_IntField_ValidInt_ReturnsTrue()
        {
            var column = new Column("Age", "int");
            var field = new Field(column, "25");

            bool isValid = field.Validate();

            Assert.That(isValid, Is.True);
        }

        [Test]
        public void Validate_ColorField_ValidColor_ReturnsTrue()
        {
            var column = new Column("BackgroundColor", "color");
            var field = new Field(column, "(255; 100; 50)");

            bool isValid = field.Validate();

            Assert.That(isValid, Is.True);
        }

        [Test]
        public void Validate_ColorIntervalField_InvalidColorRange_ReturnsFalse()
        {
            var column = new Column("Gradient", "colorInvl");
            var field = new Field(column, "(0;0;0)-(300;255;255)"); // Invalid range

            bool isValid = field.Validate();

            Assert.That(isValid, Is.False);
        }
    }
}

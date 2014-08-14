namespace Tests.TestResources
{
    using System.Collections;
    using System.Collections.Generic;
    using System.Linq;
    using System.Resources;
    using NUnit.Framework;
    using Resources;

    [TestFixture]
    public class TestResources
    {
        private List<string> englishResources;
        private List<string> frenchResources;

        [SetUp]
        public void SetUp()
        {
            englishResources = GetResourcesKeys("en");
            frenchResources = GetResourcesKeys("fr");
        }

        [Test]
        public void Resources_FrenchResources_SameKeysThanEnglishResources()
        {
            // Assert
            var deficitInFrenchResources = englishResources.Except(frenchResources).ToList();
            var surplusInFrenchResources = frenchResources.Except(englishResources).ToList();

            // Assert
            Assert.AreEqual(0, deficitInFrenchResources.Count);
            Assert.AreEqual(0, surplusInFrenchResources.Count);
        }

        /// <summary>
        /// Get a list of keys for a resource
        /// </summary>
        private List<string> GetResourcesKeys(string resourceName)
        {
            ResourceSet resourcesSet = Resource.ResourceManager.GetResourceSet(new System.Globalization.CultureInfo(resourceName), true, true);
            IDictionaryEnumerator resourcesEnumerator = resourcesSet.GetEnumerator();

            var keys = new List<string>();

            while (resourcesEnumerator.MoveNext())
            {
                keys.Add((string)resourcesEnumerator.Key);
            }

            return keys;
        }
    }
}
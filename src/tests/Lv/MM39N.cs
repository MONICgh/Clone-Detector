using NUnit.Framework;

namespace GroupWord
{
    internal class GroupWordTest
    {
        [Test]
        public void Test1()
        {
            string output = GroupWord.Group("Это что же получается: ходишь, ходишь в школу, а потом бац - вторая смена");
            string answer = "Группа 1. Длина 3. Количество 3\nэто\nчто\nбац\n\n" +
                "Группа 2. Длина 6. Количество 3\nходишь\nходишь\nвторая\n\n" +
                "Группа 3. Длина 5. Количество 3\nшколу\nпотом\nсмена\n\n" +
                "Группа 4. Длина 1. Количество 2\nв\nа\n\n" +
                "Группа 5. Длина 2. Количество 1\nже\n\n" +
                "Группа 6. Длина 10. Количество 1\nполучается\n\n";
            Assert.IsTrue(answer == output);
        }
    }
}

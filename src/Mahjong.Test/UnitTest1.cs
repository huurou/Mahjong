using Mahjong.Model.Configs;
using Mahjong.Model.Settings;
using Moq;

namespace Mahjong.Test;

public class UnitTest1
{
    [Fact]
    public void Test1()
    {
        // Arrange
        var settingRepository = new Mock<ISettingRepository>();
        settingRepository.Setup(x => x.Load()).Returns(Setting.Default);

        // Action

        // Assert
        Assert.Equal("Mahjong", AppInfo.Name);
    }
}

// Arrange

// Action

// Assert

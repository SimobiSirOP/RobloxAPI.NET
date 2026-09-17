namespace RobloxCloudApi.APITypes;

public enum RobloxThumbnailShape
{
    ROUND,
    SQUARE
}

public enum RobloxThumbnailFormat
{
    PNG,
    JPG,
    WEBP
}

// 48, 50, 60, 75, 100, 110, 150, 180, 352, 420, 720. Default is 420. 
public enum RobloxThumbnailSize
{
    Size48 = 48,
    Size50 = 50,
    Size60 = 60,
    Size75 = 75,
    Size100 = 100,
    Size110 = 110,
    Size150 = 150,
    Size180 = 180,
    Size352 = 352,
    Size420 = 420,
    Size720 = 720
}
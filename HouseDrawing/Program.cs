// See https://aka.ms/new-console-template for more information
using static System.Convert;
using static SplashKitSDK.SplashKit;

const int SCREEN_WIDTH = 1280;
const int SCREEN_HEIGHT = 720;
const int HILL_HEIGHT = SCREEN_HEIGHT / 2;
const int BOTTOM_GAP = 100;

int houseSize;
string userInput;
int wallX, wallY;
int roofleft, roofMiddle, roofRight, roofTop;
int roofOverhang, roofHeight;

WriteLine("Enter the size of the house: ");
userInput = ReadLine();
houseSize = ToInt32(userInput);
wallX = (SCREEN_WIDTH - houseSize) / 2;
wallY = SCREEN_HEIGHT - BOTTOM_GAP - houseSize;

roofOverhang = houseSize / 4;
roofHeight = houseSize * 3 / 4;
roofleft = wallX - roofOverhang;
roofMiddle = wallX + houseSize / 2;
roofRight = wallX + houseSize + roofOverhang;
roofTop = wallY - roofHeight;



OpenWindow("House Drawing", SCREEN_WIDTH, SCREEN_HEIGHT);
ClearScreen(ColorWhite());
FillEllipse(ColorBrightGreen(), 0, HILL_HEIGHT, SCREEN_WIDTH, HILL_HEIGHT);
 
FillRectangle(ColorGray(), wallX, wallY, houseSize, houseSize); // Sky
FillTriangle(ColorRed(), roofleft, wallY, roofMiddle, roofTop, roofRight, wallY); // Roof
RefreshScreen();
Delay(50000);

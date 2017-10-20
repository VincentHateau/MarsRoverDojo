using System.Collections.Generic;
using MarsRoverDojo;
using Xunit;

namespace MarsRoverTests
{
    public class Tests
    {
        [Theory]
        [InlineData(1 , 2, Direction.North, 1, 3)]
        [InlineData(1 , 2, Direction.East, 2, 2)]
        [InlineData(1 , 2, Direction.South, 1, 1)]
        [InlineData(1 , 2, Direction.West, 0, 2)]
        public void Should_Move_Forward_When_Seeing_Specific_Direction(int x, int y, Direction direction, int xExpected, int yExpected)
        {
            MarsRover marsRover = new MarsRover(x, y, direction);

            marsRover.GoForward();
            
            Assert.Equal(new Point(xExpected, yExpected), marsRover.Point);
        }
        
        [Fact]
        public void Should_Dont_Move_Forward_When_Obstacle()
        {
            List<Point> obstacles = new List<Point>()
            {    
                new Point(0, 1)
            };
            
            MarsRover marsRover = new MarsRover(0, 0, Direction.North, obstacles);

            marsRover.GoForward();
            
            Assert.Equal(new Point(0, 0), marsRover.Point);
        }
        
        [Theory]
        [InlineData(0, 200, Direction.North, 0, -200)]
        [InlineData(200, 0, Direction.East, -200, 0)]
        [InlineData(0, -200, Direction.South, 0, 200)]
        [InlineData(-200, 0, Direction.West, 200, 0)]
        public void Should_Move_Forward_When_Out_Of_The_World(int x, int y, Direction direction, int xExpected, int yExpected)
        {
            MarsRover marsRover = new MarsRover(x, y, direction);

            marsRover.GoForward();
            
            Assert.Equal(new Point(xExpected, yExpected), marsRover.Point);
        }
        
        [Theory]
        [InlineData(0, -200, Direction.North, 0, 200)]
        [InlineData(-200, 0, Direction.East, 200, 0)]
        public void Should_Move_Back_When_Out_Of_The_World(int x, int y, Direction direction, int xExpected, int yExpected)
        {
            MarsRover marsRover = new MarsRover(x, y, direction);

            marsRover.GoBack();
            
            Assert.Equal(new Point(xExpected, yExpected), marsRover.Point);
        }
        
        [Fact]
        public void Should_Move_Forward_When_Out_Of_The_World_With_Obstacle()
        {
            List<Point> obstacles = new List<Point>()
            {
                new Point(0, -200)
            };
            
            MarsRover marsRover = new MarsRover(0, 200, Direction.North, obstacles);

            marsRover.GoForward();
            
            Assert.Equal(new Point(0, 200), marsRover.Point);
        }
        
        [Fact]
        public void Should_Dont_Move_Back_When_Obstacle()
        {
            List<Point> obstacles = new List<Point>()
            {    
                new Point(0, -1)
            };
            
            MarsRover marsRover = new MarsRover(0, 0, Direction.North, obstacles);

            marsRover.GoBack();
            
            Assert.Equal(new Point(0, 0), marsRover.Point);
        }
        
        [Theory]
        [InlineData(1 , 2, Direction.North, 1, 1)]
        [InlineData(1 , 2, Direction.East, 0, 2)]
        [InlineData(1 , 2, Direction.South, 1, 3)]
        [InlineData(1 , 2, Direction.West, 2, 2)]
        public void Should_Move_Back_When_Seeing_Specific_Direction(int x, int y, Direction direction, int xExpected, int yExpected)
        {
            MarsRover marsRover = new MarsRover(x, y, direction);

            marsRover.GoBack();
            
            Assert.Equal(new Point(xExpected, yExpected), marsRover.Point);
        }

        [Theory]
        [InlineData(Direction.North, Direction.West)]
        [InlineData(Direction.West, Direction.South)]
        [InlineData(Direction.South, Direction.East)]
        [InlineData(Direction.East, Direction.North)]
        public void Should_Turn_Left_When_Seeing_Specific_Direction(Direction direction, Direction directionExpected)
        {
            MarsRover marsRover = new MarsRover(1, 2, direction);

            marsRover.TurnLeft();
            
            Assert.Equal(directionExpected, marsRover.Direction);
        }
        
        [Theory]
        [InlineData(Direction.North, Direction.East)]
        [InlineData(Direction.West, Direction.North)]
        [InlineData(Direction.South, Direction.West)]
        [InlineData(Direction.East, Direction.South)]
        public void Should_Turn_Right_When_Seeing_Specific_Direction(Direction direction, Direction directionExpected)
        {
            MarsRover marsRover = new MarsRover(1, 2, direction);

            marsRover.TurnRight();
            
            Assert.Equal(directionExpected, marsRover.Direction);
        }

        [Theory]
        [InlineData("F", 0, 0, Direction.North, 0, 1)]
        [InlineData("RF", 0, 0, Direction.North, 1, 0)]
        [InlineData("FFRFF", 0, 0, Direction.North, 2, 2)]
        [InlineData("FFLFF", 0, 0, Direction.North, -2, 2)]
        public void Should_Move_Correctly_With_Command_Without_Obstacle(string command, int x, int y, Direction direction, int xExpected, int yExpected)
        {            
            MarsRover marsRover = new MarsRover(x, y, direction);

            marsRover.ExecuteCommand(command);
            
            Assert.Equal(new Point(xExpected, yExpected), marsRover.Point);
        }
        
        [Theory]
        [InlineData("F", 0, 0, Direction.North, 0, 1)]
        [InlineData("FRF", 0, 0, Direction.North, 0, 1)]
        [InlineData("FFRFF", 0, 0, Direction.North, 2, 2)]
        [InlineData("BF", 0, 0, Direction.North, 0, 1)]
        public void Should_Move_Correctly_With_Command_With_Obstacle(string command, int x, int y, Direction direction, int xExpected, int yExpected)
        {            
            List<Point> obstacles = new List<Point>()
            {
                new Point(1, 1),
                new Point(0, -1),
            };
            
            MarsRover marsRover = new MarsRover(x, y, direction, obstacles);

            marsRover.ExecuteCommand(command);
            
            Assert.Equal(new Point(xExpected, yExpected), marsRover.Point);
        }
    }
}
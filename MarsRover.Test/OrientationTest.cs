using System.Collections.Generic;
using System.Numerics;
using MarsRover.Core.Orientation;
using MarsRover.Domain;
using Xunit;
using Xunit.Extensions;

namespace MarsRover.Test
{
    public class OrientationTest
    {

        #region TestCollections

        public static IEnumerable<object[]> GetOrientationShouldReturnSameWithExpectedOrientationCollection
        {
            get
            {
                return new[]
                {
                    new object[] { new EOrientation(), Orientations.E },
                    new object[] { new NOrientation(), Orientations.N },
                    new object[] { new WOrientation(), Orientations.W },
                    new object[] { new SOrientation(), Orientations.S }
                };
            }
        }
        public static IEnumerable<object[]> LeftShouldUpdateRoversOrientationToLeftNeigbourCollection
        {
            get
            {
                return new[]
                {
                    new object[] { new EOrientation(), Orientations.N },
                    new object[] { new NOrientation(), Orientations.W },
                    new object[] { new WOrientation(), Orientations.S },
                    new object[] { new SOrientation(), Orientations.E }
                };
            }
        }
        public static IEnumerable<object[]> RightShouldUpdateRoversOrientationToRightNeigbourCollection
        {
            get
            {
                return new[]
                {
                    new object[] { new EOrientation(), Orientations.S },
                    new object[] { new NOrientation(), Orientations.E },
                    new object[] { new WOrientation(), Orientations.N },
                    new object[] { new SOrientation(), Orientations.W }
                };
            }
        }
        public static IEnumerable<object[]> GetDiffreneceShouldReturnSameWithExpectedVector2Collection
        {
            get
            {
                return new[]
                {
                    new object[] { new EOrientation(), new Vector2(1,0) },
                    new object[] { new NOrientation(), new Vector2(0,1) },
                    new object[] { new WOrientation(), new Vector2(-1,0) },
                    new object[] { new SOrientation(), new Vector2(0,-1) }
                };
            }
        }

        #endregion

        [Theory, MemberData(nameof(GetOrientationShouldReturnSameWithExpectedOrientationCollection))]
        public void GetOrientation_Should_Return_Same_With_Expected_Orientation(IOrientation orientation, Orientations expectedOrientation)
        {
            //arrange
            //act
            //assert
            Assert.Equal(expectedOrientation,orientation.GetOrientationType());
        }

        [Theory, MemberData(nameof(LeftShouldUpdateRoversOrientationToLeftNeigbourCollection))]
        public void Left_Should_Update_Rovers_Orientation_To_Left_Neigbour(IOrientation orientation, Orientations expectedOrientation)
        {
            //arrange
            //act
            //assert
            Assert.Equal(expectedOrientation,orientation.Left().GetOrientationType());
        }
        
        [Theory, MemberData(nameof(RightShouldUpdateRoversOrientationToRightNeigbourCollection))]
        public void Right_Should_Update_Rovers_Orientation_To_Right_Neigbour(IOrientation orientation, Orientations expectedOrientation)
        {
            //arrange
            //act
            //assert
            Assert.Equal(expectedOrientation,orientation.Right().GetOrientationType());
            
        }
       
        [Theory, MemberData(nameof(GetDiffreneceShouldReturnSameWithExpectedVector2Collection))]
        public void GetDiffrenece_Should_Return_Same_With_Expected_Vector2(IOrientation orientation,Vector2 expectedDifference)
        {
            //arrange
            //act
            //assert
            Assert.Equal(expectedDifference,orientation.GetDiffrenece());
        }
    }
}
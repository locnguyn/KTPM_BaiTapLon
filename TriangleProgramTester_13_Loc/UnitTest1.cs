using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using BaiTapLonKTPM_13_Loc;
using System.Globalization;

namespace TriangleProgramTester_13_Loc
{
    [TestClass]
    public class UnitTest1
    {
        public TestContext TestContext { get; set; }
        private Triangle t_13_loc;

        //Test chức năng xác định loại tam giác
        [DataSource("Microsoft.VisualStudio.TestTools.DataSource.CSV",
            @".\Data_13_Loc\TestDataLoaiTamGiac_13_Loc.csv", "TestDataLoaiTamGiac_13_Loc#csv", DataAccessMethod.Sequential)]
        [TestMethod]
        public void TestCheckTypeOfTriangleMethod()
        {
            double a_13_loc, b_13_loc, c_13_loc;
            TypeOfTriangle expectedType_13_loc, actualType_13_loc;
            a_13_loc = Convert.ToDouble(TestContext.DataRow[1].ToString().TrimStart('a'), CultureInfo.InvariantCulture);
            b_13_loc = Convert.ToDouble(TestContext.DataRow[2].ToString().TrimStart('a'), CultureInfo.InvariantCulture);
            c_13_loc = Convert.ToDouble(TestContext.DataRow[3].ToString().TrimStart('a'), CultureInfo.InvariantCulture);
            expectedType_13_loc = (TypeOfTriangle)Enum.Parse(typeof(TypeOfTriangle), TestContext.DataRow[4].ToString());
            t_13_loc = new Triangle(a_13_loc, b_13_loc, c_13_loc);
            actualType_13_loc = t_13_loc.getType();
            Assert.AreEqual(expectedType_13_loc, actualType_13_loc);
        }

        //Test chức năng tính chu vi, diện tích
        [DataSource("Microsoft.VisualStudio.TestTools.DataSource.CSV",
            @".\Data_13_Loc\TestDataDienTichChuVi_13_Loc.csv", "TestDataDienTichChuVi_13_Loc#csv", DataAccessMethod.Sequential)]
        [TestMethod]
        public void TestCalculateAcreageAndPerimeterMethod()
        {
            double a_13_loc, b_13_loc, c_13_loc, actual_s_13_loc, expected_s_13_loc, actual_c_13_loc, expected_c_13_loc;
            a_13_loc = Convert.ToDouble(TestContext.DataRow[1].ToString().TrimStart('a'), CultureInfo.InvariantCulture);
            b_13_loc = Convert.ToDouble(TestContext.DataRow[2].ToString().TrimStart('a'), CultureInfo.InvariantCulture);
            c_13_loc = Convert.ToDouble(TestContext.DataRow[3].ToString().TrimStart('a'), CultureInfo.InvariantCulture);
            expected_s_13_loc = Convert.ToDouble(TestContext.DataRow[4].ToString().TrimStart('a'), CultureInfo.InvariantCulture);
            expected_c_13_loc = Convert.ToDouble(TestContext.DataRow[5].ToString().TrimStart('a'), CultureInfo.InvariantCulture);
            t_13_loc = new Triangle(a_13_loc, b_13_loc, c_13_loc);
            actual_s_13_loc = t_13_loc.getAcreage();
            actual_c_13_loc = t_13_loc.getPerimeter();
            Assert.AreEqual(expected_s_13_loc, actual_s_13_loc);
            Assert.AreEqual(expected_c_13_loc, actual_c_13_loc);
        }

        //Test ngoại lệ 3 cạnh không tạo thành tam giác hợp lệ (ArgumentException)
        [DataSource("Microsoft.VisualStudio.TestTools.DataSource.CSV",
            @".\Data_13_Loc\TestDataArgumentException_13_Loc.csv", "TestDataArgumentException_13_Loc#csv", DataAccessMethod.Sequential)]
        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void TestArgumentException()
        {
            double a_13_loc, b_13_loc, c_13_loc;
            a_13_loc = Convert.ToDouble(TestContext.DataRow[0].ToString(), CultureInfo.InvariantCulture);
            b_13_loc = Convert.ToDouble(TestContext.DataRow[1].ToString(), CultureInfo.InvariantCulture);
            c_13_loc = Convert.ToDouble(TestContext.DataRow[2].ToString(), CultureInfo.InvariantCulture);
            t_13_loc = new Triangle(a_13_loc, b_13_loc, c_13_loc);
        }

        //Test ngoại lệ nhập không đúng định dạng
        [DataSource("Microsoft.VisualStudio.TestTools.DataSource.CSV",
            @".\Data_13_Loc\TestDataFormatException_13_Loc.csv", "TestDataFormatException_13_Loc#csv", DataAccessMethod.Sequential)]
        [TestMethod]
        [ExpectedException(typeof(FormatException))]
        public void TestFormatException()
        {
            double a_13_loc, b_13_loc, c_13_loc;
            a_13_loc = Convert.ToDouble(TestContext.DataRow[0].ToString(), CultureInfo.InvariantCulture);
            b_13_loc = Convert.ToDouble(TestContext.DataRow[1].ToString(), CultureInfo.InvariantCulture);
            c_13_loc = Convert.ToDouble(TestContext.DataRow[2].ToString(), CultureInfo.InvariantCulture);
            t_13_loc = new Triangle(a_13_loc, b_13_loc, c_13_loc);
        }
    }
}

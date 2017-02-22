using ERP.Web.Models.BusinessModel;
using ERP.Web.Models.Database;
using OfficeOpenXml;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Xml;

namespace ERP.Web.Areas.TruongAnDaNang.Controllers
{
    [AuthorizeBussiness]
    public class ImportExcelController : Controller
    {
        XuLyNgayThang xulydate = new XuLyNgayThang();
        int so_dong_thanh_cong;
        int dong;
        HOPLONG_DATABASEEntities db = new HOPLONG_DATABASEEntities();
        // GET: HopLong/ImportExcel
        public ActionResult Index()
        {
            return View();
        }

        #region "Import Hàng Hóa"
        public ActionResult Import_Hanghoa()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Import_Hanghoa(HttpPostedFileBase file)
        {
            try
            {
                if (Request != null)
                {
                    HttpPostedFileBase filetonkho = Request.Files["UploadedFile"];
                    if ((filetonkho != null) && (filetonkho.ContentLength > 0) && !string.IsNullOrEmpty(filetonkho.FileName))
                    {
                        string fileName = filetonkho.FileName;
                        string fileContentType = filetonkho.ContentType;
                        byte[] fileBytes = new byte[filetonkho.ContentLength];
                        var data = filetonkho.InputStream.Read(fileBytes, 0, Convert.ToInt32(filetonkho.ContentLength));
                        //var usersList = new List<Users>();
                        using (var package = new ExcelPackage(filetonkho.InputStream))
                        {
                            var currentSheet = package.Workbook.Worksheets;
                            var workSheet = currentSheet.First();
                            var noOfCol = workSheet.Dimension.End.Column;
                            var noOfRow = workSheet.Dimension.End.Row;
                            for (int rowIterator = 2; rowIterator <= noOfRow; rowIterator++)
                            {

                                DM_HANG_HOA HH = new DM_HANG_HOA();
                                HH.MA_HANG_HT = workSheet.Cells[rowIterator, 1].Value.ToString();
                                HH.MA_HANG_NHAP = workSheet.Cells[rowIterator, 2].Value.ToString();
                                if (workSheet.Cells[rowIterator, 3].Value != null)
                                    HH.TEN_HANG = workSheet.Cells[rowIterator, 3].Value.ToString();
                                HH.MA_NHOM_HANG = workSheet.Cells[rowIterator, 4].Value.ToString();
                                if (workSheet.Cells[rowIterator, 5].Value != null)
                                    HH.SERI = workSheet.Cells[rowIterator, 5].Value.ToString();
                                if (workSheet.Cells[rowIterator, 6].Value != null)
                                    HH.DON_VI_TINH = workSheet.Cells[rowIterator, 6].Value.ToString();
                                if (workSheet.Cells[rowIterator, 7].Value != null)
                                    HH.XUAT_XU = workSheet.Cells[rowIterator, 7].Value.ToString();
                                if (workSheet.Cells[rowIterator, 8].Value != null)
                                    HH.MODEL_DAC_BIET = Convert.ToBoolean(workSheet.Cells[rowIterator, 8].Value);
                                if (workSheet.Cells[rowIterator, 9].Value != null)
                                    HH.HINH_ANH = workSheet.Cells[rowIterator, 9].Value.ToString();
                                if (workSheet.Cells[rowIterator, 10].Value != null)
                                    HH.DAC_TINH = workSheet.Cells[rowIterator, 10].Value.ToString();
                                if (workSheet.Cells[rowIterator, 11].Value != null)
                                    HH.GHI_CHU = workSheet.Cells[rowIterator, 11].Value.ToString();
                                if (workSheet.Cells[rowIterator, 12].Value != null)
                                    HH.TK_HACH_TOAN_KHO = workSheet.Cells[rowIterator, 12].Value.ToString();
                                if (workSheet.Cells[rowIterator, 13].Value != null)
                                    HH.TK_DOANH_THU = workSheet.Cells[rowIterator, 13].Value.ToString();
                                if (workSheet.Cells[rowIterator, 14].Value != null)
                                    HH.TK_CHI_PHI = workSheet.Cells[rowIterator, 14].Value.ToString();

                                db.DM_HANG_HOA.Add(HH);

                                db.SaveChanges();
                                so_dong_thanh_cong++;
                                dong = rowIterator - 1;
                            }

                        }
                    }
                }
            }
            catch (Exception Ex)
            {
                ViewBag.Error = " Đã xảy ra lỗi, Liên hệ ngay với admin. " + Environment.NewLine + " Thông tin chi tiết về lỗi:" + Environment.NewLine + Ex;
                ViewBag.Information = "Lỗi tại dòng thứ: " + dong;

            }
            finally
            {
                ViewBag.Message = "Đã import thành công " + so_dong_thanh_cong + " dòng";
            }

            return View("Index");
        }

        #endregion

        #region "Import hàng tồn kho"
        public ActionResult Import_HangTonKho()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Import_HangTonKho(HttpPostedFileBase file)
        {
            try
            {
                if (Request != null)
                {
                    HttpPostedFileBase filetonkho = Request.Files["UploadedFile"];
                    if ((filetonkho != null) && (filetonkho.ContentLength > 0) && !string.IsNullOrEmpty(filetonkho.FileName))
                    {
                        string fileName = filetonkho.FileName;
                        string fileContentType = filetonkho.ContentType;
                        byte[] fileBytes = new byte[filetonkho.ContentLength];
                        var data = filetonkho.InputStream.Read(fileBytes, 0, Convert.ToInt32(filetonkho.ContentLength));
                        //var usersList = new List<Users>();
                        using (var package = new ExcelPackage(filetonkho.InputStream))
                        {
                            var currentSheet = package.Workbook.Worksheets;
                            var workSheet = currentSheet.First();
                            var noOfCol = workSheet.Dimension.End.Column;
                            var noOfRow = workSheet.Dimension.End.Row;
                            for (int rowIterator = 2; rowIterator <= noOfRow; rowIterator++)
                            {
                                DM_HANG_TON_KHO HH = new DM_HANG_TON_KHO();
                                HH.MA_HANG_HT = workSheet.Cells[rowIterator, 1].Value.ToString();
                                HH.MA_KHO = workSheet.Cells[rowIterator, 2].Value.ToString();
                                HH.SL_TON = Convert.ToInt32(workSheet.Cells[rowIterator, 3].Value.ToString());

                                db.DM_HANG_TON_KHO.Add(HH);

                                db.SaveChanges();
                                so_dong_thanh_cong++;
                                dong = rowIterator - 1;
                            }

                        }
                    }
                }
            }
            catch (Exception Ex)
            {
                ViewBag.Error = " Đã xảy ra lỗi, Liên hệ ngay với admin. " + Environment.NewLine + " Thông tin chi tiết về lỗi:" + Environment.NewLine + Ex;
                ViewBag.Information = "Lỗi tại dòng thứ: " + dong;

            }
            finally
            {
                ViewBag.Message = "Đã import thành công " + so_dong_thanh_cong + " dòng";
            }

            return View("Index");
        }

        #endregion


        #region "Import kho"
        public ActionResult Import_Kho()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Import_Kho(HttpPostedFileBase file)
        {
            try
            {
                if (Request != null)
                {
                    HttpPostedFileBase filetonkho = Request.Files["UploadedFile"];
                    if ((filetonkho != null) && (filetonkho.ContentLength > 0) && !string.IsNullOrEmpty(filetonkho.FileName))
                    {
                        string fileName = filetonkho.FileName;
                        string fileContentType = filetonkho.ContentType;
                        byte[] fileBytes = new byte[filetonkho.ContentLength];
                        var data = filetonkho.InputStream.Read(fileBytes, 0, Convert.ToInt32(filetonkho.ContentLength));
                        //var usersList = new List<Users>();
                        using (var package = new ExcelPackage(filetonkho.InputStream))
                        {
                            var currentSheet = package.Workbook.Worksheets;
                            var workSheet = currentSheet.First();
                            var noOfCol = workSheet.Dimension.End.Column;
                            var noOfRow = workSheet.Dimension.End.Row;
                            for (int rowIterator = 2; rowIterator <= noOfRow; rowIterator++)
                            {
                                DM_KHO kho = new DM_KHO();
                                kho.MA_KHO = workSheet.Cells[rowIterator, 1].Value.ToString();
                                kho.TEN_KHO = workSheet.Cells[rowIterator, 2].Value.ToString();
                                kho.DIA_CHI_KHO = workSheet.Cells[rowIterator, 3].Value.ToString();
                                kho.MA_KHO_CHA = workSheet.Cells[rowIterator, 4].Value.ToString();
                                kho.TRUC_THUOC = workSheet.Cells[rowIterator, 5].Value.ToString();
                                kho.GHI_CHU = workSheet.Cells[rowIterator, 6].Value.ToString();

                                db.DM_KHO.Add(kho);

                                db.SaveChanges();
                                so_dong_thanh_cong++;
                                dong = rowIterator - 1;
                            }

                        }
                    }
                }
            }
            catch (Exception Ex)
            {
                ViewBag.Error = " Đã xảy ra lỗi, Liên hệ ngay với admin. " + Environment.NewLine + " Thông tin chi tiết về lỗi:" + Environment.NewLine + Ex;
                ViewBag.Information = "Lỗi tại dòng thứ: " + dong;

            }
            finally
            {
                ViewBag.Message = "Đã import thành công " + so_dong_thanh_cong + " dòng";
            }

            return View("Index");
        }

        #endregion

        #region "Import Phòng Ban"
        public ActionResult Import_PhongBan()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Import_PhongBan(FormCollection formCollection)
        {
            try
            {
                if (Request != null)
                {
                    HttpPostedFileBase file = Request.Files["UploadedFile"];
                    if ((file != null) && (file.ContentLength > 0) && !string.IsNullOrEmpty(file.FileName))
                    {
                        string fileName = file.FileName;
                        string fileContentType = file.ContentType;
                        byte[] fileBytes = new byte[file.ContentLength];
                        var data = file.InputStream.Read(fileBytes, 0, Convert.ToInt32(file.ContentLength));
                        //var usersList = new List<Users>();
                        using (var package = new ExcelPackage(file.InputStream))
                        {
                            var currentSheet = package.Workbook.Worksheets;
                            var workSheet = currentSheet.First();
                            var noOfCol = workSheet.Dimension.End.Column;
                            var noOfRow = workSheet.Dimension.End.Row;
                            for (int rowIterator = 2; rowIterator <= noOfRow; rowIterator++)
                            {
                                CCTC_PHONG_BAN phongban = new CCTC_PHONG_BAN();
                                phongban.MA_PHONG_BAN = workSheet.Cells[rowIterator, 1].Value.ToString();
                                phongban.TEN_PHONG_BAN = workSheet.Cells[rowIterator, 2].Value.ToString();
                                if (workSheet.Cells[rowIterator, 3].Value != null)
                                    phongban.SDT = workSheet.Cells[rowIterator, 3].Value.ToString();
                                phongban.MA_CONG_TY = workSheet.Cells[rowIterator, 4].Value.ToString();
                                if (workSheet.Cells[rowIterator, 5].Value != null)
                                    phongban.GHI_CHU = workSheet.Cells[rowIterator, 5].Value.ToString();
                                db.CCTC_PHONG_BAN.Add(phongban);

                                db.SaveChanges();
                                so_dong_thanh_cong++;
                                dong = rowIterator - 1;
                            }
                        }
                    }
                }
            }
            catch (Exception Ex)
            {
                ViewBag.Error = " Đã xảy ra lỗi, Liên hệ ngay với admin. " + Environment.NewLine + " Thông tin chi tiết về lỗi:" + Environment.NewLine + Ex;
                ViewBag.Information = "Lỗi tại dòng thứ: " + dong;

            }
            finally
            {
                ViewBag.Message = "Đã import thành công " + so_dong_thanh_cong + " dòng";
            }
            return View("Index");
        }
        #endregion

        #region "Import nhan vien"
        public ActionResult Import_Nhanvien()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Import_Nhanvien(HttpPostedFileBase file)
        {
            try
            {
                if (Request != null)
                {
                    HttpPostedFileBase filetonkho = Request.Files["UploadedFile"];
                    if ((filetonkho != null) && (filetonkho.ContentLength > 0) && !string.IsNullOrEmpty(filetonkho.FileName))
                    {
                        string fileName = filetonkho.FileName;
                        string fileContentType = filetonkho.ContentType;
                        byte[] fileBytes = new byte[filetonkho.ContentLength];
                        var data = filetonkho.InputStream.Read(fileBytes, 0, Convert.ToInt32(filetonkho.ContentLength));
                        //var usersList = new List<Users>();
                        using (var package = new ExcelPackage(filetonkho.InputStream))
                        {
                            var currentSheet = package.Workbook.Worksheets;
                            var workSheet = currentSheet.First();
                            var noOfCol = workSheet.Dimension.End.Column;
                            var noOfRow = workSheet.Dimension.End.Row;
                            for (int rowIterator = 2; rowIterator <= noOfRow; rowIterator++)
                            {
                                HT_NGUOI_DUNG user = new HT_NGUOI_DUNG();
                                user.USERNAME = workSheet.Cells[rowIterator, 2].Value.ToString();
                                user.PASSWORD = workSheet.Cells[rowIterator, 3].Value.ToString();
                                user.HO_VA_TEN = workSheet.Cells[rowIterator, 1].Value.ToString();
                                if (workSheet.Cells[rowIterator, 6].Value != null)
                                    user.SDT = workSheet.Cells[rowIterator, 6].Value.ToString();
                                if (workSheet.Cells[rowIterator, 7].Value != null)
                                    user.EMAIL = workSheet.Cells[rowIterator, 7].Value.ToString();
                                if (workSheet.Cells[rowIterator, 10].Value != null)
                                    user.AVATAR = workSheet.Cells[rowIterator, 10].Value.ToString();
                                if (workSheet.Cells[rowIterator, 13].Value != null)
                                    user.IS_ADMIN = Convert.ToBoolean(workSheet.Cells[rowIterator, 13].Value);
                                user.ALLOWED = Convert.ToBoolean(workSheet.Cells[rowIterator, 14].Value);
                                user.MA_CONG_TY = workSheet.Cells[rowIterator, 12].Value.ToString();

                                db.HT_NGUOI_DUNG.Add(user);


                                CCTC_NHAN_VIEN nhanvien = new CCTC_NHAN_VIEN();
                                nhanvien.USERNAME = workSheet.Cells[rowIterator, 2].Value.ToString();
                                if (workSheet.Cells[rowIterator, 5].Value != null)
                                    nhanvien.GIOI_TINH = workSheet.Cells[rowIterator, 5].Value.ToString();
                                if (workSheet.Cells[rowIterator, 4].Value != null)
                                    nhanvien.NGAY_SINH = xulydate.Xulydatetime(workSheet.Cells[rowIterator, 4].Value.ToString());
                                if (workSheet.Cells[rowIterator, 8].Value != null)
                                    nhanvien.QUE_QUAN = workSheet.Cells[rowIterator, 8].Value.ToString();
                                if (workSheet.Cells[rowIterator, 9].Value != null)
                                    nhanvien.TRINH_DO_HOC_VAN = workSheet.Cells[rowIterator, 9].Value.ToString();
                                if (workSheet.Cells[rowIterator, 11].Value != null)
                                    nhanvien.MA_PHONG_BAN = workSheet.Cells[rowIterator, 11].Value.ToString();

                                db.CCTC_NHAN_VIEN.Add(nhanvien);

                                db.SaveChanges();
                                so_dong_thanh_cong++;
                                dong = rowIterator - 1;
                            }

                        }
                    }
                }
            }
            catch (Exception Ex)
            {
                ViewBag.Error = " Đã xảy ra lỗi, Liên hệ ngay với admin. " + Environment.NewLine + " Thông tin chi tiết về lỗi:" + Environment.NewLine + Ex;
                ViewBag.Information = "Lỗi tại dòng thứ: " + dong;

            }
            finally
            {
                ViewBag.Message = "Đã import thành công " + so_dong_thanh_cong + " dòng";
            }

            return View("Index");
        }

        #endregion


        // Update hàng tồn kho
        #region "update hàng tồn kho"
        public ActionResult Update_HangTonKho()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Update_HangTonKho(HttpPostedFileBase file)
        {
            try
            {
                if (Request != null)
                {
                    HttpPostedFileBase filetonkho = Request.Files["UpdateFile"];
                    if ((filetonkho != null) && (filetonkho.ContentLength > 0) && !string.IsNullOrEmpty(filetonkho.FileName))
                    {
                        string fileName = filetonkho.FileName;
                        string fileContentType = filetonkho.ContentType;
                        byte[] fileBytes = new byte[filetonkho.ContentLength];
                        var data = filetonkho.InputStream.Read(fileBytes, 0, Convert.ToInt32(filetonkho.ContentLength));
                        //var usersList = new List<Users>();
                        using (var package = new ExcelPackage(filetonkho.InputStream))
                        {
                            var currentSheet = package.Workbook.Worksheets;
                            var workSheet = currentSheet.First();
                            var noOfCol = workSheet.Dimension.End.Column;
                            var noOfRow = workSheet.Dimension.End.Row;
                            for (int rowIterator = 2; rowIterator <= noOfRow; rowIterator++)
                            {
                                var mahang = workSheet.Cells[rowIterator, 1].Value.ToString();
                                var makho = workSheet.Cells[rowIterator, 2].Value.ToString();
                                var tonkho = db.DM_HANG_TON_KHO.Where(x => x.MA_HANG_HT == mahang && x.MA_KHO == makho).FirstOrDefault();
                                tonkho.SL_TON = Convert.ToInt32(workSheet.Cells[rowIterator, 3].Value.ToString());
                                db.SaveChanges();
                                so_dong_thanh_cong++;
                                dong = rowIterator - 1;
                            }

                        }
                    }
                }
            }
            catch (Exception Ex)
            {
                ViewBag.Error = " Đã xảy ra lỗi, Liên hệ ngay với admin. " + Environment.NewLine + " Thông tin chi tiết về lỗi:" + Environment.NewLine + Ex;
                ViewBag.Information = "Lỗi tại dòng thứ: " + dong;

            }
            finally
            {
                ViewBag.Message = "Đã import thành công " + so_dong_thanh_cong + " dòng";
            }

            return View("Index");
        }

        #endregion

        // Update hàng người dùng + nhân viên
        #region "Update nhan vien"
        public ActionResult Update_Nhanvien()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Update_Nhanvien(HttpPostedFileBase file)
        {
            try
            {
                if (Request != null)
                {
                    HttpPostedFileBase filetonkho = Request.Files["UpdateFile"];
                    if ((filetonkho != null) && (filetonkho.ContentLength > 0) && !string.IsNullOrEmpty(filetonkho.FileName))
                    {
                        string fileName = filetonkho.FileName;
                        string fileContentType = filetonkho.ContentType;
                        byte[] fileBytes = new byte[filetonkho.ContentLength];
                        var data = filetonkho.InputStream.Read(fileBytes, 0, Convert.ToInt32(filetonkho.ContentLength));
                        //var usersList = new List<Users>();
                        using (var package = new ExcelPackage(filetonkho.InputStream))
                        {
                            var currentSheet = package.Workbook.Worksheets;
                            var workSheet = currentSheet.First();
                            var noOfCol = workSheet.Dimension.End.Column;
                            var noOfRow = workSheet.Dimension.End.Row;
                            for (int rowIterator = 2; rowIterator <= noOfRow; rowIterator++)
                            {
                                var usname = workSheet.Cells[rowIterator, 2].Value.ToString();
                                var user = db.HT_NGUOI_DUNG.Where(x => x.USERNAME == usname).FirstOrDefault();


                                user.PASSWORD = workSheet.Cells[rowIterator, 3].Value.ToString();
                                user.HO_VA_TEN = workSheet.Cells[rowIterator, 1].Value.ToString();
                                if (workSheet.Cells[rowIterator, 6].Value != null)
                                    user.SDT = workSheet.Cells[rowIterator, 6].Value.ToString();
                                if (workSheet.Cells[rowIterator, 7].Value != null)
                                    user.EMAIL = workSheet.Cells[rowIterator, 7].Value.ToString();
                                if (workSheet.Cells[rowIterator, 10].Value != null)
                                    user.AVATAR = workSheet.Cells[rowIterator, 10].Value.ToString();
                                if (workSheet.Cells[rowIterator, 13].Value != null)
                                    user.IS_ADMIN = Convert.ToBoolean(workSheet.Cells[rowIterator, 13].Value);
                                user.ALLOWED = Convert.ToBoolean(workSheet.Cells[rowIterator, 14].Value);
                                user.MA_CONG_TY = workSheet.Cells[rowIterator, 12].Value.ToString();

                                var nhanvien = db.CCTC_NHAN_VIEN.Where(x => x.USERNAME == usname).FirstOrDefault();
                                
                                if (workSheet.Cells[rowIterator, 5].Value != null)
                                    nhanvien.GIOI_TINH = workSheet.Cells[rowIterator, 5].Value.ToString();
                                if (workSheet.Cells[rowIterator, 4].Value != null)
                                    nhanvien.NGAY_SINH = xulydate.Xulydatetime(workSheet.Cells[rowIterator, 4].Value.ToString());
                                if (workSheet.Cells[rowIterator, 8].Value != null)
                                    nhanvien.QUE_QUAN = workSheet.Cells[rowIterator, 8].Value.ToString();
                                if (workSheet.Cells[rowIterator, 9].Value != null)
                                    nhanvien.TRINH_DO_HOC_VAN = workSheet.Cells[rowIterator, 9].Value.ToString();
                                if (workSheet.Cells[rowIterator, 11].Value != null)
                                    nhanvien.MA_PHONG_BAN = workSheet.Cells[rowIterator, 11].Value.ToString();

                                db.SaveChanges();
                                so_dong_thanh_cong++;
                                dong = rowIterator - 1;
                            }

                        }
                    }
                }
            }
            catch (Exception Ex)
            {
                ViewBag.Error = " Đã xảy ra lỗi, Liên hệ ngay với admin. " + Environment.NewLine + " Thông tin chi tiết về lỗi:" + Environment.NewLine + Ex;
                ViewBag.Information = "Lỗi tại dòng thứ: " + dong;

            }
            finally
            {
                ViewBag.Message = "Đã import thành công " + so_dong_thanh_cong + " dòng";
            }

            return View("Index");
        }

        #endregion
    }
}
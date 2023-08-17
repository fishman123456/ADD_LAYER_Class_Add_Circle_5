using Autodesk.AutoCAD.DatabaseServices;
using Autodesk.AutoCAD.Runtime;
using AcadApp = Autodesk.AutoCAD.ApplicationServices;
using Autodesk.AutoCAD.ApplicationServices;
using Autodesk.AutoCAD.EditorInput;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using Autodesk.AutoCAD.Publishing;
using Autodesk.AutoCAD.Geometry;

namespace ADD_LAYER_Class_Add_Circle_5
{
    public class Class2_Class_add_Layer
    {
        [CommandMethod("ADD_Win")]

        //принимает массив строк
        public void AddWin()
        {
            Form1 form = new Form1();
            form.ShowDialog();
        }

            // TODO: добавляем слой в чертеж
            [CommandMethod("ADD_LAYER")]

        //принимает массив строк
        public void AddLayer(string[]s)
        {


            AcadApp.Document adoc = AcadApp.Application.DocumentManager.MdiActiveDocument;
            Database db = adoc.Database;
            Editor ed = adoc.Editor;

            // работа с окном и списками
            //UserControl2 userControl2 = new UserControl2();
            //AcadApp.Application.ShowModalWindow(userControl2);
            Form1 form = new Form1();
            form.ShowDialog();

            //
           // string s = "MyLayers";
            using (Transaction tr = db.TransactionManager.StartTransaction())
            // получаем таблицу слоёв
            {

                try
                {
                    LayerTable lt = (LayerTable)tr.GetObject(db.LayerTableId, OpenMode.ForRead);
                    // если название не удалено и такого еще нет в таблице слоев
                    // используем длину массива строк, для количества циклов 
                    for (int i = 0; i < s.Length; i++)
                    {
                        if (!lt.Has(s[i]))
                        {
                            LayerTableRecord ltr = new LayerTableRecord();
                            ltr.Name = s[i] + " " + i.ToString();

                            lt.UpgradeOpen();
                            lt.Add(ltr);
                            tr.AddNewlyCreatedDBObject(ltr, true);
                        }
                        else
                        {
                            AcadApp.Application.ShowAlertDialog("Такой слой уже есть! \n" + s[i]);
                        }
                    }
                    tr.Commit();
                }

                catch (System.Exception ex)
                {
                    AcadApp.Application.ShowAlertDialog(ex.Message);
                }
            }
        }
    }// конец for в этот цикл надо поместить функцию которая окружность чертит
}

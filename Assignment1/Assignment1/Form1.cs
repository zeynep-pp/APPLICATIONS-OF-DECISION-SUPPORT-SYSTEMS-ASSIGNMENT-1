using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using weka;
using weka.core.converters;
using System.Collections.Generic;
namespace Assignment1
{
    public partial class Form1 : Form
    {

        static weka.core.Instances insts = null;
        static int numAtt = 0;
        Label[] labels;
        ComboBox[] nominal;
        TextBox[] numeric;
        bool[] typeAtt;
        string fileName;
        int height = 0;

        const int percentSplit = 66;

        static weka.classifiers.Classifier NaiveBayescl = null;
        static weka.classifiers.Classifier LogRegressioncl = null;
        static weka.classifiers.Classifier Knncl = null;
        static weka.classifiers.Classifier J48cl = null;
        static weka.classifiers.Classifier RandomForestcl = null;
        static weka.classifiers.Classifier RandomTreecl = null;
        static weka.classifiers.Classifier Anncl = null;
        static weka.classifiers.Classifier Svmcl = null;

        static weka.classifiers.Classifier model = null;
        string name;


        public Form1()
        {
            InitializeComponent();
            height = this.Height;
            btnResult.Enabled = false;
        }



        //Naive Bayes
        public static double NaiveBayesTest(weka.core.Instances insts)
        {
            try
            {
                insts.setClassIndex(insts.numAttributes() - 1);

                NaiveBayescl = new weka.classifiers.bayes.NaiveBayes();

                //discretize
                weka.filters.Filter myDiscretize = new weka.filters.unsupervised.attribute.Discretize();
                myDiscretize.setInputFormat(insts);
                insts = weka.filters.Filter.useFilter(insts, myDiscretize);

                weka.filters.Filter myRandom = new weka.filters.unsupervised.instance.Randomize();
                myRandom.setInputFormat(insts);
                insts = weka.filters.Filter.useFilter(insts, myRandom);

                int trainSize = insts.numInstances() * percentSplit / 100;
                int testSize = insts.numInstances() - trainSize;
                weka.core.Instances train = new weka.core.Instances(insts, 0, trainSize);

                NaiveBayescl.buildClassifier(train);

                int numCorrect = 0;
                for (int i = trainSize; i < insts.numInstances(); i++)
                {
                    weka.core.Instance currentInst = insts.instance(i);
                    double predictedClass = NaiveBayescl.classifyInstance(currentInst);
                    if (predictedClass == insts.instance(i).classValue())
                        numCorrect++;
                }
                return (double)numCorrect / (double)testSize * 100.0;
            }
            catch (java.lang.Exception ex)
            {
                ex.printStackTrace();
                return 0;
            }
        }

        //Logistic regression
        public static double LogRegressionTest(weka.core.Instances insts)
        {
            try
            {
                insts.setClassIndex(insts.numAttributes() - 1);

                LogRegressioncl = new weka.classifiers.functions.Logistic();

                weka.filters.Filter myDummy = new weka.filters.unsupervised.attribute.NominalToBinary();
                myDummy.setInputFormat(insts);
                insts = weka.filters.Filter.useFilter(insts, myDummy);

                weka.filters.Filter myNormalize = new weka.filters.unsupervised.instance.Normalize();
                myNormalize.setInputFormat(insts);
                insts = weka.filters.Filter.useFilter(insts, myNormalize);

                weka.filters.Filter myRandom = new weka.filters.unsupervised.instance.Randomize();
                myRandom.setInputFormat(insts);
                insts = weka.filters.Filter.useFilter(insts, myRandom);

                int trainSize = insts.numInstances() * percentSplit / 100;
                int testSize = insts.numInstances() - trainSize;
                weka.core.Instances train = new weka.core.Instances(insts, 0, trainSize);

                LogRegressioncl.buildClassifier(train);

                int numCorrect = 0;
                for (int i = trainSize; i < insts.numInstances(); i++)
                {
                    weka.core.Instance currentInst = insts.instance(i);
                    double predictedClass = LogRegressioncl.classifyInstance(currentInst);
                    if (predictedClass == insts.instance(i).classValue())
                        numCorrect++;
                }
                return (double)numCorrect / (double)testSize * 100.0;
            }
            catch (java.lang.Exception ex)
            {
                ex.printStackTrace();
                return 0;
            }
        }

        //Knn
        public static double Knn(weka.core.Instances insts)
        {
            try
            {

                insts.setClassIndex(insts.numAttributes() - 1);

                Knncl = new weka.classifiers.lazy.IBk();

                weka.filters.Filter myDummy = new weka.filters.unsupervised.attribute.NominalToBinary();
                myDummy.setInputFormat(insts);
                insts = weka.filters.Filter.useFilter(insts, myDummy);

                weka.filters.Filter myNormalize = new weka.filters.unsupervised.instance.Normalize();
                myNormalize.setInputFormat(insts);
                insts = weka.filters.Filter.useFilter(insts, myNormalize);

                weka.filters.Filter myRandom = new weka.filters.unsupervised.instance.Randomize();
                myRandom.setInputFormat(insts);
                insts = weka.filters.Filter.useFilter(insts, myRandom);

                int trainSize = insts.numInstances() * percentSplit / 100;
                int testSize = insts.numInstances() - trainSize;
                weka.core.Instances train = new weka.core.Instances(insts, 0, trainSize);

                Knncl.buildClassifier(train);


                int numCorrect = 0;
                for (int i = trainSize; i < insts.numInstances(); i++)
                {
                    weka.core.Instance currentInst = insts.instance(i);
                    double predictedClass = Knncl.classifyInstance(currentInst);
                    if (predictedClass == insts.instance(i).classValue())
                        numCorrect++;
                }
                return (double)numCorrect / (double)testSize * 100.0;
            }
            catch (java.lang.Exception ex)
            {
                ex.printStackTrace();
                return 0;
            }
        }


        //J48
        public static double J48classifyTest(weka.core.Instances insts)
        {
            try
            {

                insts.setClassIndex(insts.numAttributes() - 1);

                J48cl = new weka.classifiers.trees.J48();

                weka.filters.Filter myRandom = new weka.filters.unsupervised.instance.Randomize();
                myRandom.setInputFormat(insts);
                insts = weka.filters.Filter.useFilter(insts, myRandom);

                int trainSize = insts.numInstances() * percentSplit / 100;
                int testSize = insts.numInstances() - trainSize;
                weka.core.Instances train = new weka.core.Instances(insts, 0, trainSize);

                J48cl.buildClassifier(train);

                int numCorrect = 0;
                for (int i = trainSize; i < insts.numInstances(); i++)
                {
                    weka.core.Instance currentInst = insts.instance(i);
                    double predictedClass = J48cl.classifyInstance(currentInst);
                    if (predictedClass == insts.instance(i).classValue())
                        numCorrect++;
                }
                return (double)numCorrect / (double)testSize * 100.0;
            }
            catch (java.lang.Exception ex)
            {
                ex.printStackTrace();
                return 0;
            }
        }

        //Random Forest
        public static double RandomForestTest(weka.core.Instances insts)
        {
            try
            {

                insts.setClassIndex(insts.numAttributes() - 1);

                RandomForestcl = new weka.classifiers.trees.RandomForest();

                weka.filters.Filter myRandom = new weka.filters.unsupervised.instance.Randomize();
                myRandom.setInputFormat(insts);
                insts = weka.filters.Filter.useFilter(insts, myRandom);

                int trainSize = insts.numInstances() * percentSplit / 100;
                int testSize = insts.numInstances() - trainSize;
                weka.core.Instances train = new weka.core.Instances(insts, 0, trainSize);

                RandomForestcl.buildClassifier(train);


                int numCorrect = 0;
                for (int i = trainSize; i < insts.numInstances(); i++)
                {
                    weka.core.Instance currentInst = insts.instance(i);
                    double predictedClass = RandomForestcl.classifyInstance(currentInst);
                    if (predictedClass == insts.instance(i).classValue())
                        numCorrect++;
                }
                return (double)numCorrect / (double)testSize * 100.0;
            }
            catch (java.lang.Exception ex)
            {
                ex.printStackTrace();
                return 0;
            }
        }

        //Random Tree
        public static double RandomTreeTest(weka.core.Instances insts)
        {
            try
            {

                insts.setClassIndex(insts.numAttributes() - 1);

                RandomTreecl = new weka.classifiers.trees.RandomTree();

                weka.filters.Filter myRandom = new weka.filters.unsupervised.instance.Randomize();
                myRandom.setInputFormat(insts);
                insts = weka.filters.Filter.useFilter(insts, myRandom);

                int trainSize = insts.numInstances() * percentSplit / 100;
                int testSize = insts.numInstances() - trainSize;
                weka.core.Instances train = new weka.core.Instances(insts, 0, trainSize);

                RandomTreecl.buildClassifier(train);

                int numCorrect = 0;
                for (int i = trainSize; i < insts.numInstances(); i++)
                {
                    weka.core.Instance currentInst = insts.instance(i);
                    double predictedClass = RandomTreecl.classifyInstance(currentInst);
                    if (predictedClass == insts.instance(i).classValue())
                        numCorrect++;
                }
                return (double)numCorrect / (double)testSize * 100.0;
            }
            catch (java.lang.Exception ex)
            {
                ex.printStackTrace();
                return 0;
            }
        }

        //Artificial NN
        public static double ArtificialNN(weka.core.Instances insts)
        {
            try
            {
                insts.setClassIndex(insts.numAttributes() - 1);

                Anncl = new weka.classifiers.functions.MultilayerPerceptron();

                weka.filters.Filter myDummy = new weka.filters.unsupervised.attribute.NominalToBinary();
                myDummy.setInputFormat(insts);
                insts = weka.filters.Filter.useFilter(insts, myDummy);

                weka.filters.Filter myNormalize = new weka.filters.unsupervised.instance.Normalize();
                myNormalize.setInputFormat(insts);
                insts = weka.filters.Filter.useFilter(insts, myNormalize);

                weka.filters.Filter myRandom = new weka.filters.unsupervised.instance.Randomize();
                myRandom.setInputFormat(insts);
                insts = weka.filters.Filter.useFilter(insts, myRandom);

                int trainSize = insts.numInstances() * percentSplit / 100;
                int testSize = insts.numInstances() - trainSize;
                weka.core.Instances train = new weka.core.Instances(insts, 0, trainSize);

                Anncl.buildClassifier(train);

                int numCorrect = 0;
                for (int i = trainSize; i < insts.numInstances(); i++)
                {
                    weka.core.Instance currentInst = insts.instance(i);
                    double predictedClass = Anncl.classifyInstance(currentInst);
                    if (predictedClass == insts.instance(i).classValue())
                        numCorrect++;
                }
                return (double)numCorrect / (double)testSize * 100.0;
            }
            catch (java.lang.Exception ex)
            {
                ex.printStackTrace();
                return 0;
            }
        }

        //SVM
        public static double SVM(weka.core.Instances insts)
        {
            try
            {
                insts.setClassIndex(insts.numAttributes() - 1);

                Svmcl = new weka.classifiers.functions.SMO();

                weka.filters.Filter myDummy = new weka.filters.unsupervised.attribute.NominalToBinary();
                myDummy.setInputFormat(insts);
                insts = weka.filters.Filter.useFilter(insts, myDummy);

                weka.filters.Filter myNormalize = new weka.filters.unsupervised.instance.Normalize();
                myNormalize.setInputFormat(insts);
                insts = weka.filters.Filter.useFilter(insts, myNormalize);

                weka.filters.Filter myRandom = new weka.filters.unsupervised.instance.Randomize();
                myRandom.setInputFormat(insts);
                insts = weka.filters.Filter.useFilter(insts, myRandom);

                int trainSize = insts.numInstances() * percentSplit / 100;
                int testSize = insts.numInstances() - trainSize;
                weka.core.Instances train = new weka.core.Instances(insts, 0, trainSize);

                Svmcl.buildClassifier(train);

                int numCorrect = 0;
                for (int i = trainSize; i < insts.numInstances(); i++)
                {
                    weka.core.Instance currentInst = insts.instance(i);
                    double predictedClass = Svmcl.classifyInstance(currentInst);
                    if (predictedClass == insts.instance(i).classValue())
                        numCorrect++;
                }
                return (double)numCorrect / (double)testSize * 100.0;
            }
            catch (java.lang.Exception ex)
            {
                ex.printStackTrace();
                return 0;
            }
        }

        //CLEAR Function
        private void clears()
        {
            if (nominal != null && labels != null && numeric != null)
            {
                for (int i = 0; i < nominal.Length; i++)
                {
                    Controls.Remove(nominal[i]);
                }
                for (int i = 0; i < labels.Length; i++)
                {
                    Controls.Remove(labels[i]);
                }
                for (int i = 0; i < numeric.Length; i++)
                {
                    Controls.Remove(numeric[i]);
                }
            }
            lblResult.Text = "";
            lblResult2.Text = "";
            txtFilePath.Text = "";
            labels = null;
            nominal = null;
            numeric = null;
            this.Height = height;

        }

        //File selection section and percentage calculation section
        private void btnBrowse_Click(object sender, EventArgs e)
        {
            clears();
            OpenFileDialog file = new OpenFileDialog();
            file.Filter = "Files (ARFF)|*.ARFF";
            file.Multiselect = false;
            file.Title = "Please select a dataset file!";
            if (file.ShowDialog() == DialogResult.OK)
            {
                txtFilePath.Text = file.FileName;
                fileName = file.SafeFileName;

                //performs the operation after the file is selected.
                try
                {
                    if (txtFilePath.Text.Length < 1)
                    {
                        MessageBox.Show("Please select file!", "Error Message!");
                        txtFilePath.Text = "";
                    }
                    else
                    {
                        this.Text = "Processing...";
                        insts = new weka.core.Instances(new java.io.FileReader(txtFilePath.Text));
                        //naive bayes
                        double max_value = NaiveBayesTest(insts);
                        model = NaiveBayescl;
                        name = "Naive Bayes";

                        //logistic regression
                        double LogRegressionvalue = LogRegressionTest(insts);
                        if (LogRegressionvalue > max_value)
                        {
                            max_value = LogRegressionvalue;
                            model = LogRegressioncl;
                            name = "Logistic Regression";
                        }
                        //knn
                        double KnnValue = Knn(insts);
                        if (KnnValue > max_value)
                        {
                            max_value = KnnValue;
                            model = Knncl;
                            name = "K-Nearest Neighbour";
                        }
                        //J48
                        double J48Value = J48classifyTest(insts);
                        if (J48Value > max_value)
                        {
                            max_value = J48Value;
                            model = J48cl;
                            name = "Decision Tree(J48)";
                        }
                        //Random forest
                        double RFvalue = RandomForestTest(insts);
                        if (RFvalue > max_value)
                        {
                            max_value = RFvalue;
                            model = RandomForestcl;
                            name = "Decision Tree(Random Forest)";
                        }
                        //Random Tree
                        double RTvalue = RandomTreeTest(insts);
                        if (RTvalue > max_value)
                        {
                            max_value = RTvalue;
                            model = RandomTreecl;
                            name = "Decision Tree(Random Tree)";
                        }
                        //Artificial nn
                        double AnnValue = ArtificialNN(insts);
                        if (AnnValue > max_value)
                        {
                            max_value = AnnValue;
                            model = Anncl;
                            name = "Artificial Neural Network";
                        }
                        //Svm
                        double SvmValue = SVM(insts);
                        if (SvmValue > max_value)
                        {
                            max_value = SvmValue;
                            model = Svmcl;
                            name = "Support Vector Machine";
                        }

                        // Model save part
                        weka.core.SerializationHelper.write("models/mdl.model", model);

                        lblResult.Text = name + " is the best algorithm for this data set (%" + string.Format("{0:0.00}", max_value) + ")";
                        this.Text = "";

                        //selection processes
                        numAtt = insts.numAttributes() - 1;

                        int x = 30, y = 130, t = 35, l = 110;
                        int txt = 0, cmb = 0, r1 = 0, r2 = 0;
                        labels = new Label[insts.numAttributes()];
                        for (int i = 0; i < numAtt; i++)
                        {
                            if (insts.attribute(i).isNumeric())
                                txt++;
                            else if (insts.attribute(i).isNominal())
                                cmb++;
                        }

                        nominal = new ComboBox[cmb];
                        numeric = new TextBox[txt];
                        typeAtt = new bool[numAtt];
                        this.Height += (numAtt + 1) * t;

                        for (int i = 0; i < numAtt; i++)
                        {

                            if (insts.attribute(i).isNominal())
                            {
                                string[] s1 = insts.attribute(i).toString().Split('{');
                                string[] s2 = s1[1].Split('}');
                                string[] s3 = s2[0].Split(',');

                                nominal[r1] = new ComboBox();
                                labels[i] = new Label();
                                for (int j = 0; j < s3.Length; j++)
                                {
                                    nominal[r1].Items.Add(s3[j].Replace('\'', ' ').Trim());
                                }
                                labels[i].Text = insts.attribute(i).name();
                                labels[i].Left = x;
                                labels[i].Top = y;

                                nominal[r1].Left = x + l;
                                nominal[r1].Top = y;
                                nominal[r1].DropDownStyle = ComboBoxStyle.DropDownList;
                                y += t;
                                Controls.Add(nominal[r1]);
                                Controls.Add(labels[i]);
                                r1++;
                                typeAtt[i] = true;
                            }
                            else if (insts.attribute(i).isNumeric())
                            {
                                numeric[r2] = new TextBox();
                                labels[i] = new Label();
                                labels[i].Text = insts.attribute(i).name();
                                labels[i].Left = x;
                                labels[i].Top = y;
                                numeric[r2].Left = x + l;
                                numeric[r2].Top = y;
                                y += t;
                                Controls.Add(numeric[r2]);
                                Controls.Add(labels[i]);
                                r2++;
                                typeAtt[i] = false;
                            }

                            btnResult.Enabled = true;
                        }
                    }
                }
                catch (Exception e2)
                {
                    MessageBox.Show(e2.Message, "Error Message!");
                }
            }
        }

        private void btnDiscover_Click(object sender, EventArgs e)
        {
            string type = model.GetType().ToString();
            bool flag = false;
            bool flag2 = false;
            //Controls of input
            if (nominal != null)
            {
                for (int i = 0; i < nominal.Length; i++)
                {
                    if (nominal[i].SelectedIndex == -1)
                    {
                        flag = true;
                        break;
                    }
                }
            }
            if (numeric != null)
            {
                for (int i = 0; i < numeric.Length; i++)
                {
                    if (String.IsNullOrEmpty(numeric[i].Text))
                    {
                        flag2 = true;
                        break;
                    }
                }
            }
            if (numAtt == numeric.Length && flag2 == true)
            {
                MessageBox.Show("Please select value!", "Error Message!");
            }
            else if (numAtt == nominal.Length && flag == true)
            {
                MessageBox.Show("Please select value!", "Error Message!");
            }
            else if ((nominal.Length + numeric.Length) == numAtt && (flag == true || flag2 == true))
            {
                MessageBox.Show("Please select value!", "Error Message!");
            }
            else
            {
                weka.core.Instance newIns = new weka.core.Instance(numAtt + 1);
                newIns.setDataset(insts);

                int i1 = 0, i2 = 0;
                for (int i = 0; i < numAtt; i++)
                {
                    //nominal
                    if (typeAtt[i])
                    {
                        newIns.setValue(i, nominal[i1].SelectedItem.ToString());
                        i1++;
                    }
                    //numeric
                    else
                    {
                        newIns.setValue(i, double.Parse(numeric[i2].Text));
                        i2++;
                    }
                }

                weka.core.Instances insts2 = new weka.core.Instances(insts);
                insts2.add(newIns);

                if (type == "weka.classifiers.bayes.NaiveBayes")
                {
                    weka.filters.Filter myDiscretize = new weka.filters.unsupervised.attribute.Discretize();
                    myDiscretize.setInputFormat(insts2);
                    insts2 = weka.filters.Filter.useFilter(insts2, myDiscretize);
                }

                else if (type == "weka.classifiers.functions.Logistic")
                {
                    weka.filters.Filter myDummy = new weka.filters.unsupervised.attribute.NominalToBinary();
                    myDummy.setInputFormat(insts2);
                    insts2 = weka.filters.Filter.useFilter(insts2, myDummy);

                    weka.filters.Filter myNormalize = new weka.filters.unsupervised.instance.Normalize();
                    myNormalize.setInputFormat(insts2);
                    insts2 = weka.filters.Filter.useFilter(insts2, myNormalize);
                }

                else if (type == "new weka.classifiers.lazy.IBk")
                {
                    weka.filters.Filter myDummy = new weka.filters.unsupervised.attribute.NominalToBinary();
                    myDummy.setInputFormat(insts2);
                    insts2 = weka.filters.Filter.useFilter(insts2, myDummy);

                    weka.filters.Filter myNormalize = new weka.filters.unsupervised.instance.Normalize();
                    myNormalize.setInputFormat(insts2);
                    insts2 = weka.filters.Filter.useFilter(insts2, myNormalize);
                }
                else if (type == "weka.classifiers.trees.J48") { }
                else if (type == "weka.classifiers.trees.RandomForest") { }
                else if (type == "weka.classifiers.trees.RandomTree") { }
                else if (type == "weka.classifiers.functions.MultilayerPerceptron")
                {
                    weka.filters.Filter myDummy = new weka.filters.unsupervised.attribute.NominalToBinary();
                    myDummy.setInputFormat(insts2);
                    insts2 = weka.filters.Filter.useFilter(insts2, myDummy);

                    weka.filters.Filter myNormalize = new weka.filters.unsupervised.instance.Normalize();
                    myNormalize.setInputFormat(insts2);
                    insts2 = weka.filters.Filter.useFilter(insts2, myNormalize);
                }
                else if (type == "weka.classifiers.functions.SMO")
                {
                    weka.filters.Filter myDummy = new weka.filters.unsupervised.attribute.NominalToBinary();
                    myDummy.setInputFormat(insts2);
                    insts2 = weka.filters.Filter.useFilter(insts2, myDummy);

                    weka.filters.Filter myNormalize = new weka.filters.unsupervised.instance.Normalize();
                    myNormalize.setInputFormat(insts2);
                    insts2 = weka.filters.Filter.useFilter(insts2, myNormalize);
                }

                double index = model.classifyInstance(insts2.lastInstance());
                //Model reading part
                weka.classifiers.Classifier cls = (weka.classifiers.Classifier)weka.core.SerializationHelper.read("models/mdl.model");
                lblResult2.Text = "Result= " + insts2.attribute(insts2.numAttributes() - 1).value(Convert.ToInt16(index));
            }

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}

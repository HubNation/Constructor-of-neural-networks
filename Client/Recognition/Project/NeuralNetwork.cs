using System;
using System.IO;
using System.Linq;
using System.Collections.Generic;

namespace Project
{
    class NeuralNetwork
    {
        private int input_nodes;
        private int hidden_nodes;
        private int output_nodes;
        private double learning_speed;
        private double[][] weight_ih;
        private double[][] weight_ho;

        public NeuralNetwork(string name, int inodes, int hnodes, int onodes, double ls)
        {
            input_nodes = inodes;
            hidden_nodes = hnodes;
            output_nodes = onodes;
            learning_speed = ls;

            Random rand = new Random();
            weight_ih = new double[hnodes][];
            for (int i = 0; i < hnodes; i++)
            {
                weight_ih[i] = new double[inodes];
                for (int j = 0; j < inodes; j++)
                {
                    weight_ih[i][j] = rand.NextDouble() - 0.5;
                    //Console.Write(weight_ih[i, j] + " ");
                }
                //Console.WriteLine();
            }

            weight_ho = new double[onodes][];
            for (int i = 0; i < onodes; i++)
            {
                weight_ho[i] = new double[hnodes];
                for (int j = 0; j < hnodes; j++)
                {
                    weight_ho[i][j] = rand.NextDouble() - 0.5;
                    //Console.Write(weight_ho[i, j] + " ");
                }
                //Console.WriteLine();
            }

            string dir = @"Networks\" + name;
            DirectoryInfo dirInfo = new DirectoryInfo(dir);
            if (dirInfo.Exists)
            {
                read_weights(dir);
                return;
            }

            save_weights(name);
        }

        private double[][] activation_function(double[][] x)
        {
            double[][] y = new double[x.GetLength(0)][];
            for (int j = 0; j < x.Length; j++)
            {
                y[j] = new double[1];
                y[j][0] = 1 / (1 + Math.Exp(-x[j][0]));
            }

            return y;
        }

        private double[][] transpose_matrix(double[][] vec)
        {
            double[][] result = new double[vec[0].GetLength(0)][];
            for (int i = 0; i < vec[0].GetLength(0); i++)
            {
                result[i] = new double[vec.GetLength(0)];
                for (int j = 0; j < vec.GetLength(0); j++)
                    result[i][j] = vec[j][i];
            }
            return result;
        }

        private double[][] matrices_substraction(double[][] a, double[][] b)
        {
            int n = a.GetLength(0), m = a[0].GetLength(0);
            double[][] result = new double[n][];
            for (int i = 0; i < n; i++)
            {
                result[i] = new double[m];
                for (int j = 0; j < m; j++)
                {
                    result[i][j] = a[i][j] - b[i][j];
                }
            }

            return result;
        }

        private double[][] simple_substraction(double a, double[][] b)
        {
            int n = b.GetLength(0), m = b[0].GetLength(0);
            double[][] result = new double[n][];
            for (int i = 0; i < n; i++)
            {
                result[i] = new double[m];
                for (int j = 0; j < m; j++)
                {
                    result[i][j] = a - b[i][j];
                }
            }

            return result;
        }

        private double[][] matrices_addition(double[][] a, double[][] b)
        {
            int n = a.GetLength(0), m = a[0].GetLength(0);
            double[][] result = new double[n][];
            for (int i = 0; i < n; i++)
            {
                result[i] = new double[m];
                for (int j = 0; j < m; j++)
                {
                    result[i][j] = a[i][j] + b[i][j];
                }
            }

            return result;
        }

        private double[][] simple_multiplication2(double a, double[][] b)
        {
            int n = b.GetLength(0), m = b[0].GetLength(0);
            double[][] result = new double[n][];
            for (int i = 0; i < n; i++)
            {
                result[i] = new double[m];
                for (int j = 0; j < m; j++)
                {
                    result[i][j] = a * b[i][j];
                }
            }

            return result;
        }

        private double[][] simple_multiplication3(double[][] a, double[][] b, double[][] c)
        {
            int n = b.GetLength(0), m = b[0].GetLength(0);
            double[][] result = new double[n][];
            for (int i = 0; i < n; i++)
            {
                result[i] = new double[m];
                for (int j = 0; j < m; j++)
                {
                    result[i][j] = a[i][j] * b[i][j] * c[i][j];
                }
            }

            return result;
        }

        private double[][] matrices_multiplication(double[][] a, double[][] b)
        {
            int n = a.GetLength(0), m = b[0].GetLength(0);
            double[][] result = new double[n][];

            for (int i = 0; i < n; i++)
            {
                result[i] = new double[m];
                for (int j = 0; j < m; j++)
                {
                    result[i][j] = 0;
                    for (int k = 0; k < a[0].GetLength(0); k++)
                        result[i][j] += a[i][k] * b[k][j];

                }

            }

            return result;
        }

        private void train(double[][] inputs_vector, double[][] targets_vector)
        {
            double[][] inputs, targets, hidden_inputs, hidden_outputs,
                final_inputs, final_outputs, outputs_error, hidden_error, transposed_hidden_outputs,
                temporary_multiplier, transposed_inputs, transposed_weight_ho;

            inputs = transpose_matrix(inputs_vector);
            targets = transpose_matrix(targets_vector);

            hidden_inputs = matrices_multiplication(weight_ih, inputs);
            hidden_outputs = activation_function(hidden_inputs);

            final_inputs = matrices_multiplication(weight_ho, hidden_outputs);
            final_outputs = activation_function(final_inputs);

            transposed_weight_ho = transpose_matrix(weight_ho);

            outputs_error = matrices_substraction(targets, final_outputs);
            hidden_error = matrices_multiplication(transposed_weight_ho, outputs_error);

            transposed_hidden_outputs = transpose_matrix(hidden_outputs);
            temporary_multiplier = matrices_multiplication(
            simple_multiplication3(outputs_error, final_outputs, simple_substraction(1.0, final_outputs)),
            transposed_hidden_outputs);
            weight_ho = matrices_addition(weight_ho, simple_multiplication2(learning_speed, temporary_multiplier));

            transposed_inputs = transpose_matrix(inputs);
            temporary_multiplier = matrices_multiplication(
            simple_multiplication3(hidden_error, hidden_outputs, simple_substraction(1.0, hidden_outputs)),
            transposed_inputs);
            weight_ih = matrices_addition(weight_ih, simple_multiplication2(learning_speed, temporary_multiplier));
        }

        private double[][] query(double[][] inputs_vector)
        {
            double[][] inputs, hidden_inputs, hidden_outputs, final_inputs, final_outputs;
            inputs = transpose_matrix(inputs_vector);

            hidden_inputs = matrices_multiplication(weight_ih, inputs);
            hidden_outputs = activation_function(hidden_inputs);

            final_inputs = matrices_multiplication(weight_ho, hidden_outputs);
            final_outputs = activation_function(final_inputs);

            return final_outputs;
        }

        public void save_weights(string name)
        {
            string dir = @"Networks\" + name;
            DirectoryInfo dirInfo = new DirectoryInfo(dir);
            if (!dirInfo.Exists)
            {
                dirInfo.Create();
            }

            string path = dir + @"\weights.dat";
            using (BinaryWriter writer = new BinaryWriter(File.Open(path, FileMode.OpenOrCreate)))
            {
                for (int i = 0; i < hidden_nodes; i++)
                {
                    for (int j = 0; j < input_nodes; j++)
                    {
                        writer.Write(weight_ih[i][j]);
                    }
                }

                for (int i = 0; i < output_nodes; i++)
                {
                    for (int j = 0; j < hidden_nodes; j++)
                    {
                        writer.Write(weight_ho[i][j]);
                    }
                }
            }
        }

        public void read_weights(string dir)
        {
            string path = dir + @"\weights.dat";
            using (BinaryReader reader = new BinaryReader(File.Open(path, FileMode.Open)))
            {
                for (int i = 0; i < hidden_nodes; i++)
                {
                    for (int j = 0; j < input_nodes; j++)
                    {
                        weight_ih[i][j] = reader.ReadDouble();
                    }
                }

                for (int i = 0; i < output_nodes; i++)
                {
                    for (int j = 0; j < hidden_nodes; j++)
                    {
                        weight_ho[i][j] = reader.ReadDouble();
                    }
                }
            }
        }

        public void neural_network_training(string values, int amount)
        {
            string[] line_train = values.Split(',');
            double[][] values_train = new double[1][];
            values_train[0] = new double[line_train.Length];
            for (int i = 0; i < line_train.Length; i++)
            {
                if (i != 0)
                    values_train[0][i] = (Double.Parse(line_train[i]) / 255.0 * 0.99) + 0.01;
                else
                    values_train[0][i] = Double.Parse(line_train[i]);
            }

            double[][] targets_vector = new double[1][];

            targets_vector[0] = new double[amount];
            targets_vector[0] = Enumerable.Range(0, amount).Select(s => 0.1).ToArray();
            targets_vector[0][Convert.ToInt32(Math.Round(values_train[0][0]))] = 0.99;
            double[] buff = values_train[0].Skip(1).ToArray();
            values_train[0] = buff;
            train(values_train, targets_vector);
        }

        public int[] neural_network_testing(string values)
        {
            string[] line_test = values.Split(',');
            double[][] values_test = new double[1][];
            values_test[0] = new double[784];

            for (int i = 0; i < line_test.Length; i++)
            {
                values_test[0][i] = (Double.Parse(line_test[i]) / 255.0 * 0.99) + 0.01;
            }

            double[][] result_outputs_vector = new double[1][];

            result_outputs_vector = this.query(values_test);
            int[] result_vec = new int[result_outputs_vector.Length];
            for (int i = 0; i < result_outputs_vector.Length; i++)
            {
                result_vec[i] = Convert.ToInt32((result_outputs_vector[i][0] * 100));
            }

            return result_vec;
        }
    };
}

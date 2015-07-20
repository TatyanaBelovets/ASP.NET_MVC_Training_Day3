using System;
using System.ComponentModel;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Xml.Serialization;

namespace Task1.Library
{
    public sealed class Polynomial : IEquatable<Polynomial>, ICloneable
    {
        private readonly double[] _coefficients;
        public double Degree { get { return _coefficients.Length == 0 ? Double.NegativeInfinity : _coefficients.Length - 1; } }

        public Polynomial(params double[] coeffs)
        {
            if (coeffs == null)
            {
                throw new ArgumentNullException("coeffs", "Coefficients cannot be null");
            }
            var end = Array.FindLastIndex(coeffs, d => d != 0); //Finds the index of the last non-zero element
            _coefficients = new double[end + 1];
            Array.Copy(coeffs, _coefficients, _coefficients.Length);
        }

        public double this[int i] //indexer
        {
            get
            {
                if (i < 0)
                {
                    throw new ArgumentOutOfRangeException("Index should be nonnegative");
                }
                return i > Degree ? 0 : _coefficients[i];
            }
        }

        public Polynomial(Polynomial polynomial) : this(polynomial._coefficients) { }

        public bool Equals(Polynomial other)
        {
            return other != null && _coefficients.SequenceEqual(other._coefficients);
        }

        object ICloneable.Clone()
        {
            return Clone();
        }

        public Polynomial Clone()
        {
            return new Polynomial(_coefficients);
        }
        public override string ToString()
        {
            var output = new StringBuilder();
            for (int i = _coefficients.Length - 1; i >= 0; i--)
            {
                if (i == _coefficients.Length - 1)
                {
                    output.Append(String.Format("{0}x^{1}", _coefficients[i], i));
                }
                else if (i == 1)
                {
                    output.Append(String.Format("{0}{1}x", _coefficients[i] < 0 ? "" : "+", _coefficients[i]));
                }
                else if (_coefficients[i] != 0 && i != 0)
                {
                    output.Append(String.Format("{0}{1}x^{2}", _coefficients[i] < 0 ? "" : "+", _coefficients[i], i));
                }
                else if (i == 0)
                {
                    output.Append(String.Format("{0}{1}", _coefficients[i] < 0 ? "" : "+", _coefficients[i]));
                }
            }
            return output.ToString();
        }

        public override int GetHashCode()
        {
            const int prime = 17;
            return (int)_coefficients.Aggregate<double, double>(0, (hash, coeff) => hash * prime + coeff);
        }

        public override bool Equals(Object other)
        {
            var a = other as Polynomial;
            return a != null && Equals(a);
        }

        public Polynomial WithCoefficients(params Tuple<int, double>[] pairs)
        {
            if (pairs == null)
            {
                throw new ArgumentNullException("pairs");
            }
            var maxIndex = Math.Max(_coefficients.Length - 1, pairs.Max(t => t.Item1));
            var copy = new double[maxIndex + 1];
            Array.Copy(_coefficients, copy, _coefficients.Length);
            foreach (var tuple in pairs)
            {
                if (tuple.Item1 >= 0 && !Double.IsNaN(tuple.Item2))
                {
                    copy[tuple.Item1] = tuple.Item2;
                }
            }
            return new Polynomial(copy);
        }

        public static Polynomial operator +(Polynomial left, Polynomial right)
        {
            int maxLength = Math.Max(left._coefficients.Length, right._coefficients.Length);
            int minLength = Math.Min(left._coefficients.Length, right._coefficients.Length);
            double[] newCoeffs = new double[maxLength];
            for (int i = 0; i < minLength; i++)
            {
                newCoeffs[i] = Math.Round(left._coefficients[i] + right._coefficients[i]);
            }
            double[] maxLengthCoeffs = left.Degree > right.Degree ? left._coefficients : right._coefficients;
            for (int i = minLength; i < maxLength; i++)
            {
                newCoeffs[i] = maxLengthCoeffs[i];
            }
            return new Polynomial(newCoeffs);
        }

        public static Polynomial operator +(Polynomial left, double right)
        {
            return left + new Polynomial(right);
        }
        public static Polynomial operator +(double left, Polynomial right)
        {
            return right + left;
        }

        public static Polynomial operator -(Polynomial left, Polynomial right)
        {
            return left + (-right);
        }

        public static Polynomial operator -(Polynomial left, double right)
        {
            return left + new Polynomial(-right);
        }

        public static Polynomial operator -(Polynomial left)
        {
            return new Polynomial(left._coefficients.Select(elem => -elem).ToArray());
        }

        public static Polynomial operator *(Polynomial left, double right)
        {
            return new Polynomial(left._coefficients.Select(elem => right * elem).ToArray());
        }

        public static Polynomial operator *(double left, Polynomial right)
        {
            return right * left;
        }

        public static Polynomial operator /(Polynomial left, double right)
        {
            return left * (1.0 / right);
        }

        public static bool operator ==(Polynomial left, Polynomial right)
        {
            return ((object)left == null) ? (object)right == null : left.Equals(right);
        }

        public static bool operator !=(Polynomial left, Polynomial right)
        {
            return !(left == right);
        }

        public static Polynomial Add(Polynomial left, Polynomial right)
        {
            return left + right;
        }

        public static Polynomial Add(Polynomial left, double right)
        {
            return left + right;
        }

        public static Polynomial Multiply(Polynomial left, double right)
        {
            return left * right;
        }

        public static Polynomial Subtract(Polynomial left, Polynomial right)
        {
            return left - right;
        }

        public static Polynomial Subtract(Polynomial left, double right)
        {
            return left - right;
        }

        public static Polynomial Divide(Polynomial left, double right)
        {
            return left / right;
        }
    }
}

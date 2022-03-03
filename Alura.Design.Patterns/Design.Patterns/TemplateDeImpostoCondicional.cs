using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Design.Patterns
{
    public abstract class TemplateDeImpostoCondicional : IImposto
    {
        public TemplateDeImpostoCondicional(IImposto outroImposto) : base(outroImposto) { }

        public TemplateDeImpostoCondicional() : base() {} 

        public override double Calcula(Orcamento orcamento)
        {
            if (DeveUsarMaximaTaxacao(orcamento))
                return MaximaTaxacao(orcamento) + CalculoDoOutroImposto(orcamento);

            return MinimaTaxacao(orcamento) + CalculoDoOutroImposto(orcamento);
        }

        public abstract bool DeveUsarMaximaTaxacao(Orcamento orcamento);
        public abstract double MaximaTaxacao(Orcamento orcamento);
        public abstract double MinimaTaxacao(Orcamento orcamento);
    }
}

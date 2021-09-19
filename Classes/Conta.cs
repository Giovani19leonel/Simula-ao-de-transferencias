using System;

    public class Contas
    {
        private tipoconta.Tipoconta TipoConta { get; set; }
        private double Saldo { get; set; }
        private double Credito { get; set; }
        private string Nome { get; set; }
        private double Devedor { get; set; }
        
        public Contas(tipoconta.Tipoconta tipoconta, double saldo, double credito, string nome, double devedor){
		
			this.TipoConta = tipoconta;
			this.Saldo = saldo;
			this.Credito = credito;
			this.Nome = nome;
            this.Devedor = devedor;
		}
        
        public bool Sacar(double ValorSaque)
        {
            //Validação de Saldo suficiente
            if (this.Saldo - ValorSaque < this.Credito * -1)
            {
                Console.WriteLine("Saldo insuficiente!");
                return false;
            }

            if(this.Devedor<=0){
            this.Saldo -= ValorSaque;
            
            System.Console.WriteLine("Saldo atual da conta de {0} é: {1}", this.Nome, this.Saldo);
            return true;
            }
            else
            {
                System.Console.WriteLine("Não pode ser efetuado o Saque pois tem dívidas pendentes");
                return false;
            }
        }

        public void Depositar(double ValorDeposito)
        {
            this.Saldo += ValorDeposito;
            if (this.Devedor>0){
            this.Devedor -= ValorDeposito;
            }
            System.Console.WriteLine("Saldo atual da conta {0} é: {1}", this.Nome, this.Saldo);

        }

        public void Transferir(double ValorTransferencia, Contas ContaDestino)
        {
            if (this.Sacar(ValorTransferencia))
            {
                ContaDestino.Depositar(ValorTransferencia);
            }
        }

        public void TransferirPix(double valorMandado)
        {
            this.Sacar(valorMandado);
        }

        public void Emprestimo(double valorEmprestimo)
        {
            if (this.Saldo<=0)
            {
                this.Saldo += valorEmprestimo;
                this.Devedor += valorEmprestimo;
            }

            else 
            {
                System.Console.WriteLine("Para efetuar o Emprestimo seu saldo deve ser igual ou menor que R$ 0");
            }
        }


        public override string ToString()
		{
            string retorno = "";
            retorno += "TipoConta: " + this.TipoConta + " | ";
            retorno += "Nome: " + this.Nome + " | ";
            retorno += "Saldo: R$" + this.Saldo + " | ";
            retorno += "Crédito: R$" + this.Credito + " | ";
            retorno += "Saldo devedor: R$" + this.Devedor;
			return retorno;
		}
        
        public void debug()
        {
            if(this.Saldo<0)
            {
                this.Saldo = this.Saldo + this.Credito;
                this.Credito = this.Credito - this.Credito;
            }
        }
    }

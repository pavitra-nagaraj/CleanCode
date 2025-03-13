public class PrinterDriver
{
    private IInput input;
    private IPrinter printer;

    public PrinterDriver(IInput input, IPrinter printer){
        file = file;
        printer = printer;
    }


    public void Print(){
        buffer page = input.readPage();
        while(!input.EOP(page)){
            printer.Print(page);
            page = input.readPage();
        }
    }

    public interface IInput{
        bool EOP;
        void nextPage();
        void readPage();
    }
    public interface IPrinter{
        void Print();
    }

    public class PDFFile: IInput{
        bool EOP;
        void NextPage();
        void readPage();
    }
    public class MyScanner: IInput {
        bool EOP;
        void NextPage();
        void readPage();
    }
    public class ColorPrinter: IPrinter{
        void Print();
    }
    public class RadiumPrinter: IPrinter{
       void Print();
    }
    
}

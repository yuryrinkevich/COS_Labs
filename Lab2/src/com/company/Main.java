package com.company;

import java.io.File;
import java.util.Scanner;

public class Main {

    public static void main(String[] args) {
        Scanner scanner = new Scanner(System.in);
        System.out.print("Введите Путь к  файлу: ");
        String input_file_path = scanner.nextLine();
        File input = new File(input_file_path);
        System.out.print("0 - увеличить изображение\n1 - сжать изображение\n");
        String mode  = scanner.nextLine();
        System.out.print("Введите коэффициент: ");
        String ratio  = scanner.nextLine();
        if (input.exists()) {
                File output = new File(input_file_path + "new.bmp");
                // Для сжатия и последующего восстановления
                if(mode.equals("1")){
                    Neighbor.compress(input, new  Double(ratio), output);
                    System.out.print("Изображение успешно сжато\n");
                    Neighbor.resize(output, new  Double(ratio), new File(input_file_path+"restore.bmp"));
                    System.out.print("Изображение успешно восстановлено\n");
                }
                // Для увеличения и последующего восстановления
                if(mode.equals("0")){
                    Neighbor.resize(input, new  Double(ratio), output);
                    System.out.print("Изображение успешно увеличено\n");
                    Neighbor.compress(output, new  Double(ratio), new File(input_file_path+"RESTORE.bmp"));
                    System.out.print("Изображение успешно восстановлено\n");
                }
            } else {
                System.out.println("Неверно указан путь к файлу");
            }
    }
}

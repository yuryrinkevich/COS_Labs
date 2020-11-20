package com.company;

import javax.imageio.ImageIO;
import java.awt.image.BufferedImage;
import java.io.File;
import java.io.IOException;

public class Neighbor {

    public static void compress(File image, double koef, File output){
        BufferedImage sourcePicture = null;
        /* Открываем файл для чтения */
        try {
            sourcePicture = ImageIO.read(image);
        }catch (IOException e){
            System.out.println(e.getMessage());
        }
        /* Вычисляем размеры сжимаемого изображения */
        int outputWidth = (int) (sourcePicture.getWidth() / koef);
        int outputHeight = (int) (sourcePicture.getHeight() / koef);
        BufferedImage outputPicture = new BufferedImage(outputWidth, outputHeight, sourcePicture.getType());
        /* устанавливаем яркость методом ближайшего соседа для сжатия */
        double y=0, x=0;
        for(int i = 0; i < outputHeight; i++){
            for (int j = 0; j < outputWidth; j++){
                outputPicture.setRGB(j,i,sourcePicture.getRGB((int) x,(int) y));
                x+=koef;
            }
            y+=koef;
            x=0;
        }
        // сохраняем файл
        try {
            ImageIO.write(outputPicture,"bmp",output);
        } catch (IOException e) {
            e.printStackTrace();
        }
    }

    public static void resize(File image, double koef, File output) {
        BufferedImage sourcePicture = null;
        try {
            sourcePicture = ImageIO.read(image);
        }catch (IOException e){
            System.out.println(e.getMessage());
        }
        /* Вычисляем размеры увеличеваемого изображения */
        int outputWidth = (int) (sourcePicture.getWidth() * koef);
        int outputHeight = (int) (sourcePicture.getHeight() * koef);
        /* устанавливаем яркость методом ближайшего соседа для увеличения */
        double y=0, x=0;
        BufferedImage outputPicture = new BufferedImage(outputWidth, outputHeight, sourcePicture.getType());
        for (int i = 0; i < outputHeight; i++) {
            for (int j = 0; j < outputWidth; j++) {
                outputPicture.setRGB(j, i, sourcePicture.getRGB((int) x,(int) y));
                x+=(1.0/koef);
            }
            y+=(1.0/koef);
            x=0;
        }
        // сохраняем файл
        try {
            ImageIO.write(outputPicture, "bmp", output);
        } catch (IOException e) {
            e.printStackTrace();
        }
    }

}

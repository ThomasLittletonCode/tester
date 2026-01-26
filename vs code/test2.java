import javax.swing.*;
import java.awt.*;
import java.text.SimpleDateFormat;
import java.util.Date;

public class test extends JFrame {
    private JLabel timeLabel;
    private JLabel dayLabel;

    public test() {
        setTitle("Clock");
        setSize(300, 150);
        setDefaultCloseOperation(JFrame.EXIT_ON_CLOSE);
        setLayout(new GridLayout(2, 1));

        timeLabel = new JLabel("", SwingConstants.CENTER);
        dayLabel = new JLabel("", SwingConstants.CENTER);

        Font font = new Font("Arial", Font.BOLD, 20);
        timeLabel.setFont(font);
        dayLabel.setFont(font);

        add(dayLabel);
        add(timeLabel);

        updateTime();
        updateDay();

        Timer timer = new Timer(1000, e -> {
            updateTime();
            updateDay();
        });
        timer.start();
    }

    private void updateTime() {
        Date now = new Date();
        SimpleDateFormat sdf = new SimpleDateFormat("hh:mm:ss a"); // 12-hour format
        timeLabel.setText(sdf.format(now));
    }

    private void updateDay() {
        Date now = new Date();
        SimpleDateFormat sdf = new SimpleDateFormat("EEEE, MMMM dd"); // Full month name
        dayLabel.setText(sdf.format(now));
    }

    public static void main(String[] args) {
        SwingUtilities.invokeLater(() -> {
            test clock = new test();
            clock.setVisible(true);
        });
    }
}
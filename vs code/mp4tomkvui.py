import os
import subprocess
import tkinter as tk
from tkinter import filedialog, messagebox, ttk

VIDEO_FORMATS = [
    "webm", "mp4", "mkv", "avi", "mov", "flv", "wmv", "mpeg", "mpg",
    "m4v", "3gp", "ogg", "ogv", "ts", "m2ts", "vob", "divx", "xvid"
]

def convert_video(input_file, input_root, output_root, output_ext):
    rel_path = os.path.relpath(input_file, input_root)
    output_file = os.path.splitext(rel_path)[0] + f".{output_ext}"
    output_path = os.path.join(output_root, output_file)

    os.makedirs(os.path.dirname(output_path), exist_ok=True)

    command = ['ffmpeg', '-i', input_file, '-c', 'copy', output_path]

    try:
        subprocess.run(command, check=True, stdout=subprocess.DEVNULL, stderr=subprocess.STDOUT)
        print(f"✔️ Converted: {input_file} -> {output_path}")
    except subprocess.CalledProcessError:
        print(f"❌ Failed to convert: {input_file}")

def process_all(input_folder, output_folder, input_ext, output_ext):
    count = 0
    for root, _, files in os.walk(input_folder):
        for file in files:
            if file.lower().endswith(f'.{input_ext}'):
                full_path = os.path.join(root, file)
                convert_video(full_path, input_folder, output_folder, output_ext)
                count += 1
    messagebox.showinfo("Done", f"Converted {count} files.")

def select_input_folder():
    folder = filedialog.askdirectory(title="Select Input Folder")
    if folder:
        input_var.set(folder)

def select_output_folder():
    folder = filedialog.askdirectory(title="Select Output Folder")
    if folder:
        output_var.set(folder)

def start_conversion():
    input_folder = input_var.get()
    output_folder = output_var.get()
    input_ext = input_type.get().lower()
    output_ext = output_format.get().lower()

    if not input_folder or not output_folder or not input_ext or not output_ext:
        messagebox.showerror("Error", "Please fill out all fields.")
        return

    if input_ext == output_ext:
        messagebox.showwarning("Warning", "Input and output formats are the same.")
        return

    process_all(input_folder, output_folder, input_ext, output_ext)

# --- GUI Setup ---
root = tk.Tk()
root.title("Media Converter")
root.geometry("500x450")
root.configure(bg="#2b2b2b")

style = ttk.Style()
style.theme_use("clam")

# Apply dark theme styles
style.configure("TLabel", background="#2b2b2b", foreground="white")
style.configure("TEntry", fieldbackground="#3c3f41", foreground="white")

# Here is the key fix for Combobox text color:
style.configure("TCombobox", fieldbackground="#3c3f41", foreground="black")
style.map("TCombobox",
          fieldbackground=[('readonly', '#3c3f41')],
          foreground=[('readonly', 'black')])

style.configure("TButton", background="#4a4a4a", foreground="white")
style.map("TButton", background=[('active', '#5a5a5a')])

input_var = tk.StringVar()
output_var = tk.StringVar()
input_type = tk.StringVar(value="webm")
output_format = tk.StringVar(value="mkv")

ttk.Label(root, text="Input Folder:").pack(anchor='w', padx=10, pady=(10, 0))
ttk.Entry(root, textvariable=input_var, width=60).pack(padx=10)
ttk.Button(root, text="Browse", command=select_input_folder).pack(pady=5)

ttk.Label(root, text="Output Folder:").pack(anchor='w', padx=10)
ttk.Entry(root, textvariable=output_var, width=60).pack(padx=10)
ttk.Button(root, text="Browse", command=select_output_folder).pack(pady=5)

ttk.Label(root, text="Input File Type:").pack(anchor='w', padx=10, pady=(10, 0))
input_combo = ttk.Combobox(root, textvariable=input_type, values=VIDEO_FORMATS, state="readonly", width=20)
input_combo.pack(padx=10)

ttk.Label(root, text="Output File Type:").pack(anchor='w', padx=10, pady=(10, 0))
output_combo = ttk.Combobox(root, textvariable=output_format, values=VIDEO_FORMATS, state="readonly", width=20)
output_combo.pack(padx=10)

ttk.Button(root, text="Convert Files", command=start_conversion).pack(pady=30)

root.mainloop()

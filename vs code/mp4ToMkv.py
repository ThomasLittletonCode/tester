import os
from moviepy.editor import VideoFileClip
import concurrent.futures
import multiprocessing

def convert_mp4_to_mkv(input_file, output_file):
    clip = VideoFileClip(input_file)
    clip.write_videofile(output_file, codec='libx264', audio_codec='aac', threads=multiprocessing.cpu_count(), preset='ultrafast')

def convert_folder_mp4_to_mkv(input_folder, output_folder):
    # Ensure output folder exists
    os.makedirs(output_folder, exist_ok=True)

    # List all MP4 files in the input folder
    mp4_files = [file for file in os.listdir(input_folder) if file.endswith(".mp4")]

    # Function to convert a single MP4 file to MKV
    def convert_single_file(mp4_file):
        input_path = os.path.join(input_folder, mp4_file)
        output_path = os.path.join(output_folder, mp4_file.replace(".mp4", ".mkv"))
        convert_mp4_to_mkv(input_path, output_path)

    # Use ThreadPoolExecutor for parallel processing
    with concurrent.futures.ThreadPoolExecutor(max_workers=multiprocessing.cpu_count()) as executor:
        executor.map(convert_single_file, mp4_files)

# Example usage
input_folder = r'C:\server\server\movies\itunes\LEGO Star Wars_ The Complete Brick Saga\Season 1'
output_folder = r'C:\server\server\movies\itunes\LEGO Star Wars_ The Complete Brick Saga\Season 1'

convert_folder_mp4_to_mkv(input_folder, output_folder)
